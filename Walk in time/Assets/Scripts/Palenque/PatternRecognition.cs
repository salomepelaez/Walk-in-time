﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternRecognition : MonoBehaviour
{
    public GameObject point;

    public Color baseColor;
    public Color playerColor;

    private GameObject[,] points; // Buscar cómo escoger los miembros de la matriz en determinada posición

    private int width = 4;
    private int height = 4;

    public int contador;
    public bool rightChoice;

    void Start()
    {
        contador = 0;
        rightChoice = false;

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

                    //CheckPattern(i, j, colorAUsar);
                    CheckPattern(i, j, colorAUsar);
                    
                }
            }
        }
    }

    public void CheckPattern(int x, int y, Color colorAVerificar)
    {
        for (int i = 0; i <= points.Length; i++) 
        {
            for (int j = 0; j <= points.Length; j++) 
            {
                if (i < 0 || i >= width) // Este For, es el encargado de que no exceda el ancho del tablero.
                    continue; // El Continue permite saltar u omitir las sentencias restantes y continuar con la siguiente.

                if (j < 0 || j >= height) // Este if, es el encargado de que no exceda el alto del tablero.
                    continue;
                
                GameObject p = points[i, j];
                GameObject pX = points[x, j];
                GameObject pY = points[i, y]; 

                if (pX == points[0, j] && pY == points[i, 3] && rightChoice == false)
                {
                    rightChoice = true;
                    StartCoroutine("CounterIncrease");
                    Debug.Log("a");
                    Debug.Log(contador);

                }

                if (pX == points[1, j] && pY == points[i, 3] && rightChoice == false)
                {
                    rightChoice = true;
                    StartCoroutine("CounterIncrease");
                    Debug.Log("b");
                    Debug.Log(contador);

                }

                if (pX == points[2, j] && pY == points[i, 3] && rightChoice == false)
                {
                    rightChoice = true;
                    StartCoroutine("CounterIncrease");
                    Debug.Log("c");
                    Debug.Log(contador);

                }

                if (pX == points[2, j] && pY == points[i, 2] && rightChoice == false)
                {
                    rightChoice = true;
                    StartCoroutine("CounterIncrease");
                    Debug.Log("d");
                    Debug.Log(contador);

                }

                if (pX == points[2, j] && pY == points[i, 1] && rightChoice == false)
                {
                    rightChoice = true;
                    StartCoroutine("CounterIncrease");
                    Debug.Log("e");
                    Debug.Log(contador);
                }

                if (pX == points[2, j] && pY == points[i, 0] && rightChoice == false)
                {
                    rightChoice = true;
                    StartCoroutine("CounterIncrease");
                    Debug.Log("f");
                    Debug.Log(contador);

                }
                
                if (pX == points[3, j] && pY == points[i, 0] && rightChoice == false)
                {
                    rightChoice = true;
                    StartCoroutine("CounterIncrease");
                    Debug.Log("g");
                    Debug.Log(contador);                    
                }

                if(contador == 7)
                {
                    Debug.Log("ganador");
                }

            }
        }
    }

    IEnumerator CounterIncrease()
    {
        if(rightChoice == true)
            contador = contador + 1;

        yield return new WaitForSeconds(0.01f);

        rightChoice = false;
    }
}
