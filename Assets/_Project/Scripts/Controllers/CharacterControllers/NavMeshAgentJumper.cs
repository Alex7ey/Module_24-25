using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentJumper
{
    private float _jumpSpeed;
    private NavMeshAgent _agent;
    private MonoBehaviour _corutineRunner;
    private Coroutine _jumpCoroutine;
    private AnimationCurve _animationCurve;

    public bool InProcess => _jumpCoroutine != null;
    public bool IsJumping { get; private set; }

    public NavMeshAgentJumper(float jumpSpeed, NavMeshAgent agent, MonoBehaviour corutineRunner, AnimationCurve animationCurve)
    {
        _jumpSpeed = jumpSpeed;
        _agent = agent;
        _corutineRunner = corutineRunner;
        _animationCurve = animationCurve;
        _agent.autoTraverseOffMeshLink = false;
    }

    public void Jump(OffMeshLinkData offMeshLink, Vector3 targetPoint)
    {
        if (InProcess == false)
        {
            _jumpCoroutine = _corutineRunner.StartCoroutine(JumpProcess(offMeshLink, targetPoint));
            IsJumping = true;
        }
    }

    private IEnumerator JumpProcess(OffMeshLinkData offMeshLink, Vector3 targetPoint)
    {
        _agent.isStopped = true;

        Vector3 direction = (targetPoint - _agent.transform.position).normalized;
        float jumpDistance = Vector3.Distance(offMeshLink.startPos, offMeshLink.endPos);

        Vector3 startPos = _agent.transform.position;
        Vector3 endPos = _agent.transform.position + (direction * jumpDistance);

        float progress = 0f;
        float duration = Vector3.Distance(startPos, endPos) / _jumpSpeed;
        float yOffSet;

        while (progress <= duration)
        {
            yOffSet = _animationCurve.Evaluate(progress / duration);
            _agent.transform.position = Vector3.Lerp(startPos, endPos, progress / duration) + (2 * yOffSet * Vector3.up);
            progress += Time.deltaTime;
            yield return null;
        }

        _agent.CompleteOffMeshLink();
        _agent.isStopped = false;
        _jumpCoroutine = null;
    }

    public void Update() => IsJumping = false;
}
