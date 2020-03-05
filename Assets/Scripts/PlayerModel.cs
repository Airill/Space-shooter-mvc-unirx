using UniRx;

public class PlayerModel
{
    // Default values
    public int lives_base = 3;
    public float speed_base = 10;
    public float tilt_base = 5;
    public float fireRate_base = 0.25f;
    

    // Current values
    public int lives = 3;
    public ReactiveProperty<Vector3> direction = new ReactiveProperty<Vector3>();
    public float tilt;
    public float fireRate;

   // public ReactiveProperty<Vector3> position;
    

    // Some semi-private stuff
    public float nextFire;
}
