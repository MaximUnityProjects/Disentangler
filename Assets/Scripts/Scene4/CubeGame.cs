using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeGame : MonoBehaviour {
    [SerializeField] List<Color> colors;
    [SerializeField] public bool refresh;
    [SerializeField] public bool nextLevel;
    [SerializeField] List<Transform> randPositions;


    List<GameObject> cubes;
    [SerializeField] List<GameObject> helpLights;

    [SerializeField] GameObject cubePrefab;
    public static List<int> comb;
    [SerializeField] List<int> countInLevel;
    [SerializeField] List<int> colorsInLevel;
    int level = 0;
    //int cubesCouns = 5;


    List<GameObject> trash;


    private void Start() {
        //countInLevel = new List<int>() { 2, 3, 4, 8 };  //Сколько раз мигает
        //colorsInLevel = new List<int>() { 2, 2, 2, 2 }; // Какие цвета используются
        comb = new List<int>();
        trash = new List<GameObject>();
    }




    private void Update() {
        if (refresh) {
            StartGame();
            refresh = false;
        }
        if (nextLevel) {
            NextLevel();
            nextLevel = false;
        }
    }



    public void StartGame() {
        level = 0;
        NextLevel();
    }


    void NextLevel() {

        foreach (GameObject t in trash) {
            t.GetComponent<Collider>().enabled = false;
            Destroy(t, 3f);
        }
        trash.Clear();

        if (level >= countInLevel.Count) {
            End();
            return;
        }




        comb = RandComb();
        StartCoroutine(Doki());

    }

    float blackDuration = 1f;
    float colorDuration = 1f;


    IEnumerator Doki() {
        helpLights[0].GetComponent<Light>().color = Color.black;
        yield return new WaitForSeconds(2f);

        foreach (int c in comb) {
            helpLights[0].GetComponent<Light>().color = colors[c];
            yield return new WaitForSeconds(colorDuration);
            helpLights[0].GetComponent<Light>().color = Color.black;
            yield return new WaitForSeconds(blackDuration);
        }
        helpLights[0].GetComponent<Light>().color = Color.white;

        CreateCubes();
    }



    void CreateCubes() {
        int winCubePos = Random.Range(0, randPositions.Count);

        for (int i = 0; i < randPositions.Count; i++) {

            GameObject cube = Instantiate(cubePrefab, randPositions[i].position, randPositions[i].rotation);

            List<int> randComb;
            if (i == winCubePos) randComb = comb;
            else randComb = RandComb();

            if (randComb.SequenceEqual(comb)) cube.transform.name = "WinCube";

            for (int i1 = 0; i1 < countInLevel[level]; i1++) {
                Transform child = cube.transform.GetChild(i1);
                Color c = colors[randComb[i1]];
                child.GetComponent<Renderer>().material.color = c;
            }

            trash.Add(cube);

        }
        level++;
    }


    public void CubeInTrigger(bool win) {

     StartCoroutine(WinColor(win));


    }

    [SerializeField] List<GameObject> triggerLights;

    IEnumerator WinColor(bool win) {
        if (win) {
            NextLevel();
            foreach (GameObject l in triggerLights)
                l.GetComponent<Light>().color = Color.green;

        }
        else {
            StartGame();
            foreach (GameObject l in triggerLights)
                l.GetComponent<Light>().color = Color.red;
        }


        yield return new WaitForSeconds(colorDuration);

        foreach (GameObject l in triggerLights)
            l.GetComponent<Light>().color = Color.white;

    }


    List<int> RandComb() {
        List<int> _comb = new List<int>();
        for (int i = 0; i < countInLevel[level]; i++) {
            _comb.Add(Random.Range(0, colorsInLevel[level]));
        }
        print(_comb[0]);
        return _comb;
    }






    void End() {
        print("WIN!!!");
    }
}

