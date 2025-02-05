using Unity.VisualScripting;
using UnityEngine;

public class ItemToBuy : MonoBehaviour
{
    // 구입 아이템, 드랍 또는 필드 아이템보다 고성능이지만 money 차감 필요
    // 자판기 NPC에서 획득 가능, UI로 가격 띄워줘야 함
    // 차라리 자판기에 기능 통합하는 것은 어떤가 고민 중
    // 자판기에서 드랍템을 만드는 것보다 자판기가 직접 Player에 영향주는 것이 나을지도?
    public enum ItemToBuyType
    {
        MaxHpPlus,
        AttackPlus,
    }

    public ItemToBuyType itemToBuyType;
    PlayerCtrl playerCtrl;

    private void OnTriggerStay2D(Collider2D other)
    {
        // Player 감지, Submit(E에 할당)입력시 획득
        if(other.gameObject.CompareTag("Player") && Input.GetButton("Submit"))
        {
            playerCtrl = other.GetComponent<PlayerCtrl>();

            switch(itemToBuyType)
            {
                case ItemToBuyType.MaxHpPlus: // 최대 체력 증가
                    playerCtrl.MaxHP += 1;
                    Debug.Log("최대 체력 증가");
                    Destroy(gameObject);
                    break;
                
                case ItemToBuyType.AttackPlus: // 공격력 증가
                    playerCtrl.attack += 1;
                    Debug.Log("공격력 증가");
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
