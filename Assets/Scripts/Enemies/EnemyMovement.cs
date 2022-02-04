using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public float detectDistance = 8f;
    [SerializeField] Transform target;
    [SerializeField] Animator enemyAnimator;

    private void Update()
    {
        if (target != null)
        {
            enemyAnimator.SetBool("isWalking", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (target.position.x > transform.position.x) transform.localScale = new Vector3(1, 1, 1);
            else transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            enemyAnimator.SetBool("isWalking", false);
        }
    }

    private void LateUpdate()
    {
        target = FindTarget();
    }

    Transform FindTarget()
    {
        if (target == null)
        {
            Transform _target = GameObject.FindGameObjectWithTag("Player").transform;

            if (_target != null)
            {
                float _dist = Vector2.Distance(_target.position, transform.position);

                if (_dist <= detectDistance)
                {
                    return _target;
                }
                else
                {
                    return null;
                }

            } 
            else
            {
                return null;
            }
        } 
        else
        {
            float _dist = Vector2.Distance(target.position, transform.position);

            if (_dist <= detectDistance)
            {
                return target;
            }
            else
            {
                return null;
            }
        }
    }
}
