﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedPlate : MonoBehaviour
{
    public GameObject Gamemanager;
    public static int redPlateNum;
    public Rigidbody2D rb;
    public float YPosition;

    private int count = 0;
    private GameScript GameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Cat = GameObject.Find("MovingCat");
        DragCat catmove = Cat.GetComponent<DragCat>();

        GameObject Plate = this.gameObject;
        DishFalling dishFalling = Plate.GetComponent<DishFalling>();

        GameOver = Gamemanager.GetComponent<GameScript>();

        if (catmove.firstPlate == 0 && collision.gameObject.CompareTag("CatCollider"))
        {

            if (catmove.Modenumber != 3 && catmove.Modenumber != 13 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
            {
                GameOver.GameIsOver = true;
            }
            else
            {
                redPlateNum++;
            }

            rb.isKinematic = true;
            rb.velocity = new Vector2(0, 0);

            dishFalling.speed = 0;
            catmove.FirstYPosition = transform.position.y;
            YPosition = transform.position.y;
            catmove.firstPlate = 1;
            count++;
            catmove.DishCount++;
        }
        else if (catmove.firstPlate == 1 && collision.gameObject.CompareTag("PlateCollider"))
        {
            if (catmove.Modenumber != 3 && catmove.Modenumber != 13 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
            {
                GameOver.GameIsOver = true;
            }

            rb.isKinematic = true;
            rb.velocity = new Vector2(0, 0);

            dishFalling.speed = 0;

            if (count == 0)
            {
                YPosition = catmove.FirstYPosition + (catmove.DishCount * (0.2f));
            }

            //YPosition = transform.position.y;

            count++;
            //catmove.DishCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject plate = this.gameObject;

        GameObject platecollider = plate.transform.GetChild(0).gameObject;

        GameObject Cat = GameObject.Find("MovingCat");
        DragCat catmove = Cat.GetComponent<DragCat>();

        if (count == 2)
        {
            platecollider.SetActive(false);
            catmove.DishCount++;
            redPlateNum++;
            count++;
        }
    }
}
