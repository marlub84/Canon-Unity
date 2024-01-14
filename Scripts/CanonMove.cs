using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CanonMove : MonoBehaviour
{
    public GameObject cannon;
    public GameObject placeBall;
    public GameObject angle;

    public GameObject projectile;
    private Rigidbody projectileRb;

    private GameObject cloneInstance;
    private float canonRotateMin = 277;
    private float canonRotateMax = 320;
    private float canonAngleMin = 245;
    private float canonAngleMax = 315;

    private float moveSpeed = 0.8f;
    private float inputRotate;
    private float inputAngle;

    private float power = 0.12f;
    private float minPower = 0.5f;
    private float maxPower = 1.5f;
    public float powerSens = 0.3f;
    public float moveSens = 0.5f;

    private float countPower;

    private bool fireReady = false;
    private bool countFire = false;

    public GameObject powerBar;
    private PowerSlider slider;

    private GameManager gameManager;

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        slider = powerBar.GetComponentInChildren<PowerSlider>();
        StartCoroutine(CountPower());
    }

    // Update is called once per frame
    private void Update()
    {
        if (!gameManager.isGameActive)
        {
            inputRotate = Input.GetAxisRaw("Horizontal");
            inputAngle = Input.GetAxisRaw("Vertical");

            //canon rotate
            transform.Rotate(new Vector3(0, inputRotate * moveSpeed * moveSens, 0));

            //angle of canon
            cannon.transform.Rotate(new Vector3(inputAngle * moveSpeed * moveSens, 0, 0));

            //set limitation of canon angle
            if (cannon.transform.rotation.eulerAngles.x < canonRotateMin)
            {

                cannon.transform.localEulerAngles = new Vector3(canonRotateMin, 180, 180);
            }
            else if (cannon.transform.rotation.eulerAngles.x > canonRotateMax)
            {

                cannon.transform.localEulerAngles = new Vector3(canonRotateMax, 180, 180);
            }

            //set the limitation of canon rotate
            if (transform.rotation.eulerAngles.y < canonAngleMin)
            {

                transform.localEulerAngles = new Vector3(0, canonAngleMin, 0);
            }
            else if (transform.rotation.eulerAngles.y > canonAngleMax)
            {

                transform.localEulerAngles = new Vector3(0, canonAngleMax, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space) && fireReady)
            {
                countPower = power;
                countFire = true;
                // if canon have a ball you can fire
                //CanonFire(); 
            }
            // spawm ball 
            else if (Input.GetKeyDown(KeyCode.Space) && !fireReady)
            {
                //countFire = false;
                LoadCanon();

            }
            if (Input.GetKeyUp(KeyCode.Space) && countFire)
            {
                slider.SetPower(countPower);
                countFire = false;
                fireReady = true;
                CanonFire();
            }
    }
}

    private void CanonFire()
    {
        if (cloneInstance != null)
        {
            // if canon have a ball you can fire
            projectileRb = cloneInstance.GetComponent<Rigidbody>();
            Vector3 fireAngle = (angle.transform.position - placeBall.transform.position).normalized;
            projectileRb.AddForce(fireAngle * countPower * 100, ForceMode.Impulse);
            fireReady = false;


        }
        else fireReady = false;
    }

    private void LoadCanon()
    {
        
        slider.ResetSlider();
        cloneInstance = Instantiate(projectile, placeBall.transform.position, Quaternion.identity);
        fireReady = true;
    }

   private IEnumerator CountPower()
    {
        
        while (true) 
        {
            if (countFire)
            {
                countPower += power * powerSens;
                if (countPower < minPower) countPower = minPower;
                else if (countPower > maxPower) countPower = maxPower;

                slider.SetPower(countPower);
            }

            yield return new WaitForSeconds(0.1f);
        
        }
    }
}
