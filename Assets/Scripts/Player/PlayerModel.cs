using UniRx;

public class PlayerModel
{
    // Default values
    public int lives_base = 3;
    public float speed_base = 5;
    public float tilt_base = 5;
    public float fireRate_base = 0.25f;


    // Current values
    public ReactiveProperty<int> lives = new ReactiveProperty<int>(3);
    public ReactiveProperty<Vector3> movement = new ReactiveProperty<Vector3>();
    public ReactiveProperty<Vector3> position = new ReactiveProperty<Vector3>();
    public int speed = 8;

}
