<<<<<<< HEAD
using UnityEngine;
using UnityEngine.AI;

public class RotationController : Controller
{
    private readonly Transform _transform;
    private readonly float _rotationSpeed;
    private readonly NavMeshAgent _agent;
=======
////<<<<<<<< Updated upstream:Assets/_Project/Scripts/Controllers/CharacterControllers/RotationController.cs
////using UnityEngine;
////using UnityEngine.AI;

////public class RotationController : Controller
////========
//using System.IO;
//using TMPro;
//using UnityEngine;
//using UnityEngine.AI;

//public class TargetToPointRotator
////>>>>>>>> Stashed changes:Assets/_Project/Scripts/Controllers/CharacterControllers/TargetToPointRotator.cs
//{
//    private readonly Transform _transform;
//    private readonly float _rotationSpeed;
//    private readonly NavMeshAgent _agent;
>>>>>>> parent of e325804 (123)

    private Vector3 _lookAtPosition;

<<<<<<< HEAD
    public RotationController(Transform transform, float rotationSpeed, NavMeshAgent agent)
    {
        _transform = transform;
        _rotationSpeed = rotationSpeed;
        _agent = agent;

        ConfigureNavMeshAgent();
        SetLookAtPosition(transform.position + transform.forward);
    }
=======
//////<<<<<<<< Updated upstream:Assets/_Project/Scripts/Controllers/CharacterControllers/RotationController.cs
////    public RotationController(Transform transform, float rotationSpeed, NavMeshAgent agent)
////========
//    private NavMeshPath _path = new();

//    public TargetToPointRotator(Transform transform, float rotationSpeed, NavMeshAgent agent)
////>>>>>>>> Stashed changes:Assets/_Project/Scripts/Controllers/CharacterControllers/TargetToPointRotator.cs
//    {
//        _transform = transform;
//        _rotationSpeed = rotationSpeed;
//        _agent = agent;
//        _agent.updateRotation = false;

//        SetLookAtPosition(transform.position + transform.forward);
//    }
>>>>>>> parent of e325804 (123)

    public void SetLookAtPosition(Vector3 point) => _lookAtPosition = point;

    protected override void UpdateLogic(float deltaTime)
    {
        if (CanRotate())
            ProcessRotate(deltaTime);
    }

    private void ProcessRotate(float deltaTime)
    {
        Vector3 direction = _lookAtPosition - _transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion angle = Quaternion.LookRotation(direction);
            float stepRotation = _rotationSpeed * deltaTime;
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, angle, stepRotation);
        }
    }

<<<<<<< HEAD
    private bool CanRotate() => Vector3.Distance(_transform.position, _lookAtPosition) > _agent.stoppingDistance;

    private void ConfigureNavMeshAgent() => _agent.updateRotation = false;
}
=======
////<<<<<<<< Updated upstream:Assets/_Project/Scripts/Controllers/CharacterControllers/RotationController.cs
//    private bool CanRotate() => Vector3.Distance(_transform.position, _lookAtPosition) > _agent.stoppingDistance;

//    //private void ConfigureNavMeshAgent() => _agent.updateRotation = false;
////========
//    private Vector3 GetTargetRotatePoint()
//    {
//        _agent.CalculatePath(_lookAtPosition, _path);

//        if (_path.corners.Length > 0)
//        {
//            return _path.corners[1];
//        }

//        return _lookAtPosition;
//    }

//    //private bool CanRotate() => Vector3.Distance(_transform.position, _lookAtPosition) > _agent.stoppingDistance;
////>>>>>>>> Stashed changes:Assets/_Project/Scripts/Controllers/CharacterControllers/TargetToPointRotator.cs
//}
>>>>>>> parent of e325804 (123)
