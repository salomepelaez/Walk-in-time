﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternRecognition : MonoBehaviour
{
    public GameObject point;

    public Color baseColor;
    public Color playerColor;

    private GameObject[,] points;

    private int width = 4;
    private int height = 4;

    void Start()
    {
        Fill();
    }
    
    void Update()
    {
        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        PickUpPiece(mPosition);
    }

    void Fill()
    {
        points = new GameObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject p = GameObject.Instantiate(point) as GameObject;

                Vector3 position = new Vector3(x, y, 0);
                p.transform.position = position;

                points[x,y] = p;
                p.transform.SetParent(transform);
            }
        }
    }

    public void PickUpPiece(Vector3 position) 
    {
        int i = (int)(position.x + 0.5f);
        int j = (int)(position.y + 0.5f);

        if (Input.GetButtonDown("Fire1"))
        {
            if (i >= 0 && j >= 0 && i < width && j < height)
            {
                GameObject p = points[i, j];
                if (p.GetComponent<Renderer>().material.color == baseColor)
                {
                    Color colorAUsar = Color.clear;
                    colorAUsar = playerColor;

                    p.GetComponent<Renderer>().material.color = colorAUsar;

                    CheckPattern(i, j, colorAUsar);
                }
            }
        }
    }

    void CheckPattern(int x, int y, Color colorAVerificar)
    {
        int i = x - 1;
		int i2 = x + 1;
		int contador = 0;

		for(int j = y + 2; j >= y; j--)
		{
			if (j < 0 || j >= height || i < 0 || i >= width)
		    return; // Este Return cancela en caso de que se salga de la dimensión del tablero.

		    GameObject p = points[i, j];

			if (p.GetComponent<Renderer>().material.color != colorAVerificar)
			{
				return; // Revisa que sea el mismo color a verificar.
			}

			if(i >= 0 && i < width && j >= 0 && j < height)
			{
			    contador++;
			}

			if(i2 >= 0 && i2 < width && j >= 0 && j < height)
			{
			    contador++;
			}

			else
			{
				contador = 0;
			}

			if(contador == 4)
			{
				Debug.Log("Get in Loser");
				//inGame = false;
			}
		}
    }
}