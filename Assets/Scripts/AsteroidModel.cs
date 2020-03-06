using System.Collections;
using System.Collections.Generic;
using UniRx;

public class AsteroidModel
{
    // Default values
    public int damage_base = 1;
    public int scoreValue_base = 120;
    public float speed_base = 5.0f;
    public float lifetime_base = 20.0f;
    public float tumble_base = 5.0f;

    // Current values
    public int damage = 3;
    public int scoreValue = 120;
    public float speed = 5f;
    public float lifetime = 20f;
    public float tumble = 5f;
}
