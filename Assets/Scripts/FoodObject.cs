using UnityEngine;

public class FoodObject : CellObject
{
    public int foodPoints;
    public override void PlayerEntered()
    {
        Destroy(gameObject);

        GameManager.Instance.ChangeFood(foodPoints);
    }
}
