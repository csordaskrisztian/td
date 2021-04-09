using UnityEngine;

public class game : MonoBehaviour
{
    public static int hp = 5;
    public static bool gameover = false;
    public static bool gameWon = false;
    private Quaternion camDefaultrot;
    private Vector3 camDefaultpos;
    public GameObject cam;
    public GameObject rapidbutton;
    public GameObject rapidPrefab;
    public GameObject waterbutton;
    public GameObject waterPrefab;
    public GameObject freezerbutton;
    public GameObject freezerprefab;
    public GameObject buildCancelbutton;
    public GameObject pausebutton;
    public GameObject electricbutton;
    public GameObject electricprefab;
    public GameObject destroybutton;
    public GameObject currentBase;
    public GameObject currentTurret;
    public GameObject laserbutton;
    public GameObject laserprefab;
    public static bool gameIsPaused = false;
    public static int numberOfTurretsBuilt = 0;
    public GameObject buildMenuBorder;


    void Awake()
    {
        camDefaultrot = cam.transform.rotation;
        camDefaultpos = cam.transform.position;
        gameWon = false;
        Time.timeScale = 1;
        gameIsPaused = false;
        gameover = false;
        numberOfTurretsBuilt = 0;
        hp = 5;
    }

    void Update()
    {
        if (hp <= 0)
        {
            gameover = true;
            Debug.Log("bruh");

        }
    }

    public void BuildMenu(GameObject o)
    {
        ButtonsSetActive(false);

        cam.transform.position = camDefaultpos;
        Vector3 t = o.transform.position;
        t.y += 0.8f;

        cam.transform.position = new Vector3(t.x, camDefaultpos.y, (camDefaultpos.z + t.z)/2f);

        Vector3 targetDirection = t - cam.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
        cam.transform.rotation = lookRotation;
        //cam.transform.Translate(Vector3.forward * 5f);
        cam.transform.position = o.transform.position;
        cam.transform.Translate(Vector3.back * 10f);



        //cam.transform.LookAt(o.transform);

        Time.timeScale = 0f;

        if (currentBase)
        {
            currentBase.GetComponent<turretbase>().BuildMenuCanceled();

        }

        currentBase = o;

        if (currentBase.GetComponentInChildren<turretbase>().alreadybuilt == true)
        {
            destroybutton.SetActive(true);
            buildCancelbutton.SetActive(true);
        }
        else
        {
            rapidbutton.SetActive(true);
            waterbutton.SetActive(true);
            freezerbutton.SetActive(true);
            electricbutton.SetActive(true);
            buildCancelbutton.SetActive(true);
            buildMenuBorder.SetActive(true);
            laserbutton.SetActive(true);
        }

        pausebutton.SetActive(false);
        
    }


    public void cancel()
    {
        ButtonsSetActive(false);


        pausebutton.SetActive(true);

        cam.transform.rotation = camDefaultrot;
        cam.transform.position = camDefaultpos;
        Time.timeScale = 1;
        currentBase.GetComponent<turretbase>().BuildMenuCanceled();
    }

    public void Build(GameObject turret, int cost)
    {
        if (currentBase.GetComponentInChildren<turretbase>().alreadybuilt == false && spawner.buildPoints >= cost)
        {
            Vector3 pos = currentBase.transform.position;
            currentBase.GetComponentInChildren<turretbase>().alreadybuilt = true;
            spawner.buildPoints -= cost;
            currentBase.GetComponentInChildren<turretbase>().costofbuild = cost;
            currentBase.GetComponentInChildren<turretbase>().turret = Instantiate(turret, new Vector3(pos.x, pos.y + 0.7f, pos.z), Quaternion.identity, transform);

            cancel();
        }
    }

    public void ButtonsSetActive(bool b)
    {
        rapidbutton.SetActive(b);
        waterbutton.SetActive(b);
        freezerbutton.SetActive(b);
        electricbutton.SetActive(b);
        buildCancelbutton.SetActive(b);
        destroybutton.SetActive(b);
        buildMenuBorder.SetActive(b);
        laserbutton.SetActive(b);
    }

    public void RapidBuild()
    {
        Build(rapidPrefab, 4);
    }

    public void WaterBuild()
    {
        Build(waterPrefab, 6);
    }

    public void FreezeBuild()
    {
        Build(freezerprefab, 6);
    }

    public void ElectricBuild()
    {
        Build(electricprefab, 10);
    }
    public void LaserBuild()
    {
        Build(laserprefab, 8);
    }

    public void Destroy()
    {
        currentBase.GetComponentInChildren<turretbase>().alreadybuilt = false;
        spawner.buildPoints += currentBase.GetComponentInChildren<turretbase>().costofbuild / 2;
        Destroy(currentBase.GetComponentInChildren<turretbase>().turret);


        cancel();
    }
}
