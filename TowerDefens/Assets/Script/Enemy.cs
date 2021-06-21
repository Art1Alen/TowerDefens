using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float Speed, RotationSpeed;
    public Transform[] Points;
    public int CostEnemy;
    public Slider HPSlider;
    public float maxHP;
    public float Damage;

    private float HP;
    private Transform _currentPoint;
    private int index;
    private Vector3 direction;
    private ResurcesManager resurces;
    void Start()
    {
        HP = maxHP;
        index = 0;
        _currentPoint = Points[index];
        resurces = FindObjectOfType<ResurcesManager>();
    }
    void Update()
    {
        direction = _currentPoint.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, Time.deltaTime * RotationSpeed, 0);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position = Vector3.MoveTowards(transform.position, _currentPoint.position, Time.deltaTime * Speed);

        HPSlider.value = HP;

        if(transform.position == _currentPoint.position)
        {
            index++;

            if (index >= Points.Length)
            {
                Destroy(gameObject);
            }
            else
            {
                _currentPoint = Points[index];
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            HP -= Damage;

            if(HP <= 0)
            {
                Destroy(gameObject);
                resurces.StoneCount += CostEnemy;

            }

        }
    }
}
