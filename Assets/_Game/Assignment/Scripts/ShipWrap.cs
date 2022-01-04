using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;
using DefaultNamespace.ScriptableEvents;
using WrappingObstacles;

namespace Ship
{
    public class ShipWrap : MonoBehaviour
    {
        [SerializeField]
        private Wrap _shipWrap;

        [SerializeField]
        private ScriptableEventWrap _onShipOutOfLimitsEvent;

        [SerializeField]
        private Vector3 _centerPosition = Vector3.zero;

        [Header("Set these out precisly so they are out of the screen")]
        [SerializeField]
        private float _xOutOfScreenLimit = 10.35f;
        [SerializeField]
        private float _yOutOfScreenMaxLimit = 5.82f;

        private enum ShipDirection { North, East, South, West}

        private ShipDirection _shipDirection;

        private float _xLimit;
        private float _yLimit;

        // Start is called before the first frame update
        void Start()
        {
            // Set the limits
            if (_shipWrap.haveScreenAsLimit)
            {
                _xLimit = _xOutOfScreenLimit;
                _yLimit = _yOutOfScreenMaxLimit;
            }
            else
            {
                _xLimit = _shipWrap.xLimit;
                _yLimit = _shipWrap.yLimit;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (ShipOutOfBounds(new Vector2(transform.position.x, transform.position.y))) 
            {
                _onShipOutOfLimitsEvent.Wrap();
            }
        }
        /// <summary>
        /// Check if the ship is out of the bounds
        /// </summary>
        /// <param name="ShipPos"></param>
        /// <returns></returns>
        private bool ShipOutOfBounds(Vector2 ShipPos)
        {
            if (ShipPos.x > _xLimit)
            {
                _shipDirection = ShipDirection.East;
                return true;
            }
            else if (ShipPos.x < -_xLimit)
            {
                _shipDirection = ShipDirection.West;
                return true;
            }
            else if (ShipPos.y > _yLimit)
            {
                _shipDirection = ShipDirection.North;
                return true;
            }
            else if (ShipPos.y < -_yLimit)
            {
                _shipDirection = ShipDirection.South;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Moves the ship to the opposite end, gets called via scriptable event
        /// </summary>
        public void MoveShipOpp()
        {
            if (_shipDirection == ShipDirection.North)
            {
                transform.position = new Vector3(transform.position.x, -_yLimit, transform.position.z);
            }
            else if (_shipDirection == ShipDirection.East)
            {
                transform.position = new Vector3(-_xLimit, transform.position.y, transform.position.z);
            }
            else if (_shipDirection == ShipDirection.South)
            {
                transform.position = new Vector3(transform.position.x, _yLimit, transform.position.z);
            }
            else if (_shipDirection == ShipDirection.West)
            {
                transform.position = new Vector3(_xLimit, transform.position.y, transform.position.z);
            }
        }

        private void OnDrawGizmos()
        {
            if (!_shipWrap.haveScreenAsLimit)
            {
                Gizmos.DrawWireCube(_centerPosition, new Vector3(_shipWrap.xLimit * 2, _shipWrap.yLimit * 2, 0.1f));
            }
        }

    }
}
