using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentJumpController : Controller
{
    private IJumper _jumper;
    private NavMeshAgent _agent;

    public NavMeshAgentJumpController(IJumper jumper, NavMeshAgent agent)
    {
        _jumper = jumper;
        _agent = agent;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (IsOnNavMeshLink(out OffMeshLinkData navMeshLinkData))
            _jumper.Jump(navMeshLinkData);
    }

    private bool IsOnNavMeshLink(out OffMeshLinkData navMeshLinkData)
    {
        if (_agent.isOnOffMeshLink)
        {
            navMeshLinkData = _agent.currentOffMeshLinkData;
            return true;
        }

        navMeshLinkData = default;
        return false;
    }
}
