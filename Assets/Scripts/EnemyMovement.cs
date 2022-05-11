using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    public event Action OnStopFollow;
    public event Action OnStopRunAway;
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private float _rotationSpeed;
    private Coroutine _rotate;
    private bool _rotating;

    private void Start()
    {
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    public async void Follow()
    {
        Vector3 target = _target.position;
        _navMeshAgent.SetDestination(target);
        _rotate = StartCoroutine(Rotate(target));
        while (_rotating)
        {
            if (target != _target.position)
            {
                StopCoroutine(_rotate);
                Follow();
                return;
            }
            await Task.Yield();
        }
        OnStopFollow?.Invoke();
    }

    public async void RunAway()
    {
        Vector2 target = RandomTarget();
        _navMeshAgent.SetDestination(target);
        StartCoroutine(Rotate(target));
        while (_rotating) await Task.Yield();
        OnStopRunAway?.Invoke();
    }

    private IEnumerator Rotate(Vector3 target)
    {
        _rotating = true;
        yield return new WaitUntil(() => _navMeshAgent.hasPath);
        while (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
        {
            transform.up = Vector2.MoveTowards(transform.up, _navMeshAgent.velocity.normalized, _rotationSpeed);
            yield return null;
        }
        Vector2 newTarget = target - transform.position;
        while (Vector2.Angle(transform.up, newTarget) > 3)
        {
            transform.up = Vector2.MoveTowards(transform.up, newTarget, _rotationSpeed);
            transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z);
            yield return null;
        }
        _rotating = false;
    }

    private Vector2 RandomTarget()
    {
        Vector2 screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 target = new Vector2(Random.Range(-screenSize.x, screenSize.x),
                                     Random.Range(-screenSize.y, screenSize.y));
        return target;
    }
}
