using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternRecognition : MonoBehaviour
{
    GameManager manager;

    public GameObject point;
    
    public GameObject first, second;

    public Dictionary<Mesh, Mesh> dic = new Dictionary<Mesh, Mesh>();

    public Color baseColor;
    public Color playerColor;

    private GameObject[,] points; // Buscar cómo escoger los miembros de la matriz en determinada posición

    public Mesh[] pieces = new Mesh[16];
    public List<Mesh> piecesList = new List<Mesh>();
    private int width = 4;
    private int height = 4;

    public Mesh smallTree, cubeTree, pine, cubeTreeDark, treeThin, statue, mushrooms, roundTree, yellowFlower, stone, woodStack, roundTreeDark, grass, largeGrass, hugeTree, canoe;
    
    public void Awake()
    {
        References();
    }

    public void References()
    {
        dic.Add(pieces[0], smallTree);
        dic.Add(pieces[1], cubeTree);
        dic.Add(pieces[2], pine);
        dic.Add(pieces[3], cubeTreeDark);
        dic.Add(pieces[4], treeThin);
        dic.Add(pieces[5], statue);
        dic.Add(pieces[6], mushrooms);
        dic.Add(pieces[7], roundTree);
        dic.Add(pieces[8], yellowFlower);
        dic.Add(pieces[9], stone);
        dic.Add(pieces[10], woodStack);
        dic.Add(pieces[11], roundTreeDark);
        dic.Add(pieces[12], grass);
        dic.Add(pieces[13], largeGrass);
        dic.Add(pieces[14], hugeTree);
        dic.Add(pieces[15], canoe);
    }


    public void Start()
    {
        manager = GameManager.Instance;
        manager.contador = 0;
        manager.wrongChoices = 3;
        manager.rightChoice = false;
        manager.wrongChoice = false;

        Fill();

        for (int i = 0; i < pieces.Length; i++)
        {
            piecesList.Add(pieces[i]);
            //piecesList.Add(pieces[i]);
        }

        /*
        {
            transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>() = piecesList[i];
            transform.GetChild(i).GetChild(0).GetComponent<GameManager>().myType = dic[piecesList[i]];
        }*/
    }
    
    void Update()
    {
        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        PickUpPiece(mPosition);

        //manager.attemptsText.text = "Intentos: " + manager.wrongChoices;
    }

    void Fill()
    {
        points = new GameObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {                
                GameObject p = new GameObject();
                MeshFilter meshFilter = p.AddComponent<MeshFilter>();
                                
                for (int i = 0; i < pieces.Length; i++)
                {
                    p.GetComponent<MeshFilter>().mesh = piecesList[i];
                    //p.GetComponent<GameManager>().myType = dic[piecesList[i]];
                    //p.AddComponent<MeshRenderer>();                    
                    //Mesh mesh = meshFilter.mesh;
                }
               
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
                    manager.pointReference.Add(p);
                    //CheckPattern(i, j, colorAUsar);
                    //CheckPattern(i, j, colorAUsar);
                    
                }
            }
        }
    }

    
    /*private void CheckIfMatch()
    {
        if(first.GetComponent<GameManager>().myType == second.GetComponent<GameManager>().myType)
        {
            Debug.Log("chi cheñol");
        }

        else if (first.GetComponent<GameManager>().myType != second.GetComponent<GameManager>().myType)
        {            
            Debug.Log("no cheñol");
        }
    }

    public void AddReference(GameObject reference)
    {
        if (first == null)
        {
            first = reference; 
        }

        else if (first != reference)
        {
            second = reference;
            CheckIfMatch();
        }
    }*/
}
