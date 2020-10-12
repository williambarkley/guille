using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy Enemy;
    public GameObject MedKit;
    public Asteroid Asteroid;

    float timer;
    float maxTimer;
    int count;
    int iterations;

    //min x, min y      max x, max y
    KeyValuePair<KeyValuePair<float, float>, KeyValuePair<float, float>>[] outerSpawnCoordinates;
    Dictionary<int, int> opposites;

    // Start is called before the first frame update
    void Start()
    {
        maxTimer = 15;
        iterations = 1;
        count = 1;
        timer = maxTimer - 5;

        outerSpawnCoordinates = new KeyValuePair<KeyValuePair<float, float>, KeyValuePair<float, float>>[4] {
            new KeyValuePair<KeyValuePair<float,float>, KeyValuePair<float,float>>(
                new KeyValuePair<float,float>(Constant.MIN_X - Constant.LIMIT_OFFSET, Constant.MIN_Y) ,
                new KeyValuePair<float,float>(Constant.MIN_X,                         Constant.MAX_Y)),

            new KeyValuePair<KeyValuePair<float,float>, KeyValuePair<float,float>>(
                new KeyValuePair<float,float>(Constant.MAX_X,                         Constant.MIN_Y) ,
                new KeyValuePair<float,float>(Constant.MAX_X + Constant.LIMIT_OFFSET, Constant.MAX_Y)),

            new KeyValuePair<KeyValuePair<float,float>, KeyValuePair<float,float>>(
                new KeyValuePair<float,float>(Constant.MIN_X, Constant.MAX_Y                        ) ,
                new KeyValuePair<float,float>(Constant.MAX_Y, Constant.MAX_Y + Constant.LIMIT_OFFSET)),

            new KeyValuePair<KeyValuePair<float,float>, KeyValuePair<float,float>>(
                new KeyValuePair<float,float>(Constant.MIN_X, Constant.MIN_Y - Constant.LIMIT_OFFSET) ,
                new KeyValuePair<float,float>(Constant.MAX_X, Constant.MIN_Y                        ))
        };

        opposites = new Dictionary<int, int>() { { 0, 2 }, { 1, 3 }, { 2, 0 }, { 3, 1 } };
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= maxTimer)
        {
            for (int cnt = 0; cnt < Functions.rand(1, 2); cnt++)
            {
                GameObject MedKitInst = Instantiate(MedKit);
                MedKitInst.transform.position = new Vector3((float)Functions.rand(Constant.MIN_X, Constant.MAX_X),
                    (float)Functions.rand(Constant.MIN_Y, Constant.MAX_Y), 0);
            }

            for (int i = 0; i < Functions.rand(1, count); i++)
            {
                for (int cnt = 0; cnt < 4; cnt++)
                {
                    int oppositeCnt = opposites[cnt];


                    Asteroid AsteroidInst = Instantiate(Asteroid);
                    AsteroidInst.transform.position =
                        new Vector3((float)Functions.rand(outerSpawnCoordinates[cnt].Key.Key, outerSpawnCoordinates[cnt].Value.Key),
                                    (float)Functions.rand(outerSpawnCoordinates[cnt].Key.Value, outerSpawnCoordinates[cnt].Value.Value), 0);

                    Vector2 directionAsteroid = new Vector2(
                        (float)Functions.rand(outerSpawnCoordinates[oppositeCnt].Key.Key, outerSpawnCoordinates[oppositeCnt].Value.Key) - AsteroidInst.transform.position.x,
                        (float)Functions.rand(outerSpawnCoordinates[oppositeCnt].Key.Value, outerSpawnCoordinates[oppositeCnt].Value.Value) - AsteroidInst.transform.position.y);
                    Functions.normalize(ref directionAsteroid);
                    AsteroidInst.setDirection(directionAsteroid);

                    Enemy EnemyInst = Instantiate(Enemy);
                    EnemyInst.transform.position =
                        new Vector3((float)Functions.rand(outerSpawnCoordinates[cnt].Key.Key, outerSpawnCoordinates[cnt].Value.Key),
                                    (float)Functions.rand(outerSpawnCoordinates[cnt].Key.Value, outerSpawnCoordinates[cnt].Value.Value), 0);

                    Vector2 directionEnemy = new Vector2(
                        (float)Functions.rand(outerSpawnCoordinates[oppositeCnt].Key.Key, outerSpawnCoordinates[oppositeCnt].Value.Key) - EnemyInst.transform.position.x,
                        (float)Functions.rand(outerSpawnCoordinates[oppositeCnt].Key.Value, outerSpawnCoordinates[oppositeCnt].Value.Value) - EnemyInst.transform.position.y);
                    Functions.normalize(ref directionEnemy);
                    EnemyInst.setDirection(directionEnemy);
                }
            }

            iterations++;
            timer = 0;
        }

        if (iterations % 4 == 0 && maxTimer > 5)
        {
            maxTimer -= (float)Functions.rand(1, 2.5f);
            iterations++;
        }

        if (iterations % 7 == 0)
        {
            count++;
            iterations++;
        }
    }
}
