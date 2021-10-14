
using PathCreation;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PathCreator _road;
    [SerializeField] private float _offset;
    [SerializeField] private float _zoffset;
    [SerializeField] private float _speed;
    

    private float _distanceTraveled;

    private void Update()
    {
        {
            _distanceTraveled += _speed * Time.deltaTime;

                float currentDistance = _distanceTraveled + _offset;

                transform.position = _road.path.GetPointAtDistance(currentDistance, EndOfPathInstruction.Stop); 
                transform.position=new Vector3(transform.position.x+_zoffset,transform.position.y+_offset,transform.position.z);
                transform.rotation = _road.path.GetRotationAtDistance(currentDistance, EndOfPathInstruction.Stop);
        }

    }
}
