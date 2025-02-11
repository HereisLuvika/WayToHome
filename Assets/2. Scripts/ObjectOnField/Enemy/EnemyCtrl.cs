using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    // Enemy의 공통 행동에 대한 변수들
    // 추적, 사망 및 아이템 드롭이 들어 갈 예정

    // public 변수

    // private 변수
    [SerializeField] Transform target;
    [SerializeField] float MaxHP = 10.0f;
    [SerializeField] float currentHP;
    [SerializeField] private float moveSpeed;

    // 하위 객체에서 읽기 필요한 변수들
    [SerializeField] private float scanningRadius;
    public float readScanningRadius {get {return scanningRadius;}}
    [SerializeField] private float damage;
    public float readDamage {get {return damage;}}

    // target인 Player를 받아온 후 초기화
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentHP = MaxHP;
    }

    // 행동에 대한 변수 넣을 예정
    void Update()
    {
        FollowingTarget(moveSpeed, scanningRadius);
    }
    
    // 사정 거리 내부에 집입하는 경우 따라가기 메서드
    public void FollowingTarget(float moveSpeed, float scanningRadius)
    {
        if(target != null)
        {
            // 플레이어가 scanningRadius 내부면 moveSpeed만큼씩 이동 시작
            if(Vector2.Distance(transform.position, target.position) < scanningRadius)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }
        }
    }
}
