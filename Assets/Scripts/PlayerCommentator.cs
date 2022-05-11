using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCommentator : MonoBehaviour
{
    [SerializeField] private Text _commentsText;
    private StringBuilder _stringBuilder = new StringBuilder();
    private List<string> _comments = new List<string>();
    private int _numberShoot;
    private Coroutine _waitShoot;

    public void CommentMove()
    {
        AddComment("Moving, ");
    }

    public void CommentRotate()
    {
        AddComment("Rotating, ");
    }

    public void CommentShoot()
    {
        if (_waitShoot == null)
            _waitShoot = StartCoroutine(WaitShoot());
        _numberShoot++;
    }

    private IEnumerator WaitShoot()
    {
        yield return new WaitForSeconds(1);
        _waitShoot = null;
        if (_numberShoot >= 2)
        {
            ShowComments("Fast shots");
            yield break;
        }
        ShowComments("Shot");
    }

    private void AddComment(string comment)
    {
        if (_comments.Count > 0)
        {
            if (_comments[_comments.Count - 1] == comment)
                return;
            if (_comments.Count > 1)
                _comments.RemoveAt(0);
            _comments.Add(comment);
        }
        else
        {
            _comments.Add(comment);
        }
    }

    public void ShowComments(string shootComment)
    {
        foreach (string name in _comments)
        {
            _stringBuilder.Append(name);
        }
        _stringBuilder.Append(shootComment);
        _commentsText.text = _stringBuilder.ToString();
        StopAllCoroutines();
        StartCoroutine(ClearComments());
    }

    private IEnumerator ClearComments()
    {
        _stringBuilder.Clear();
        _comments.Clear();
        _numberShoot = 0;
        yield return new WaitForSeconds(2);
        _commentsText.text = "";
    }
}
