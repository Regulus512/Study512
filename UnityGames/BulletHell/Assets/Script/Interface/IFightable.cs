// 전투 가능한 오브젝트
// 플레이어, 보스 오브젝트가 상속받음
public interface IFightable
{
    void Attack();
    void Damaged(int damage);
}