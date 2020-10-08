using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class GameController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Queue<GameObject> bullets;
    public int maxBullets;

    // Start is called before the first frame update
    void Start()
    {
        BuildBulletPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildBulletPool()
    {
        bullets = new Queue<GameObject>();
        for (int count = 0; count < maxBullets; count++)
        {
            var tempBullet = Instantiate(bulletPrefab);
            tempBullet.SetActive(false);
            bullets.Enqueue(tempBullet);
        }
    }

    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = bullets.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bullets.Enqueue(bullet);
    }
}
