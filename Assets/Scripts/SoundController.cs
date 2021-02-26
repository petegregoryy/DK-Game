using UnityEngine;
using System.Collections;

// Simple class to controll sounds of the car, based on engine throttle and RPM, and skid velocity.
[RequireComponent(typeof(Drivetrain))]
[RequireComponent(typeof(CarController))]
public class SoundController : MonoBehaviour {

    public AudioClip engine1;
    //public AudioClip engine2;
    public AudioClip skid;
    public AudioClip shiftUp;
    public AudioClip shiftDown;
    public AudioClip blowOffValve;
    public AudioClip[] transmission;
    public AudioClip[] backfire;

    AudioSource engineSource1;
    AudioSource engineSource2;
    AudioSource skidSource;
    AudioSource shiftUpSource;
    AudioSource shiftDownSource;
    AudioSource blowOffValveSource;
    AudioSource transmissionOnSource;
    AudioSource transmissionOffSource;
    public AudioSource backfireSource;

    CarController car;
    Drivetrain drivetrain;

    AudioSource CreateAudioSource(AudioClip clip, string name) {
        GameObject go = new GameObject(name);
        go.transform.parent = transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;
        go.AddComponent(typeof(AudioSource));
        go.GetComponent<AudioSource>().clip = clip;
        go.GetComponent<AudioSource>().loop = true;
        go.GetComponent<AudioSource>().volume = 0.05f;
        go.GetComponent<AudioSource>().spatialBlend = 1f;
        go.GetComponent<AudioSource>().dopplerLevel = 0f;
        go.GetComponent<AudioSource>().Play();
        return go.GetComponent<AudioSource>();
    }

    AudioSource CreateAudioSourceShift(AudioClip clip, string name) {
        GameObject go = new GameObject(name);
        go.transform.parent = transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;
        go.AddComponent(typeof(AudioSource));
        go.GetComponent<AudioSource>().clip = clip;
        go.GetComponent<AudioSource>().loop = false;
        go.GetComponent<AudioSource>().volume = 0.50f;
        go.GetComponent<AudioSource>().spatialBlend = 1f;
        go.GetComponent<AudioSource>().dopplerLevel = 0f;
        return go.GetComponent<AudioSource>();
    }

    void Start() {
        engineSource1 = CreateAudioSource(engine1, "Engine Audio 1");
        engineSource1.transform.localPosition = new Vector3(0f, 0.5f, 1.3f);
        //engineSource2 = CreateAudioSource(engine2 , "Engine Audio 2");

        skidSource = CreateAudioSource(skid, "Skidding Audio");
        car = GetComponent(typeof(CarController)) as CarController;
        drivetrain = GetComponent(typeof(Drivetrain)) as Drivetrain;

        shiftUpSource = CreateAudioSourceShift(shiftUp, "Shift Up Audio");
        shiftUpSource.volume = 0.1f;
        shiftDownSource = CreateAudioSourceShift(shiftDown, "Shift Down Audio");
        shiftDownSource.volume = 0.1f;

        blowOffValveSource = CreateAudioSourceShift(blowOffValve, "Blow Off Valve Audio");
        blowOffValveSource.transform.localPosition = new Vector3(-0.3f, 0.8f, 1.3f);

        transmissionOnSource = CreateAudioSource(transmission[2], "Transmission On Audio");
        transmissionOffSource = CreateAudioSource(transmission[1], "Transmission Off Audio");
    }

    public void playShiftUp() {
        shiftUpSource.Play();
    }

    public void playShiftDown() {
        shiftDownSource.Play();
    }

    public void playBOV() {
        if ((drivetrain.rpm / drivetrain.maxRPM) > 0.80f)
            blowOffValveSource.Play();
    }

    public void playBackFire() {
        backfireSource.clip = backfire[Random.Range(0, 3)];
        backfireSource.Play();
    }

    int currSpeed, lastSpeed, difference;

    void Update() {

        engineSource1.pitch = 0.15f + drivetrain.rpm / drivetrain.powerRPM; //was 0.20
        engineSource1.volume = 0.35f + 0.60f * drivetrain.throttle;


        float skidVol = Mathf.Clamp01(Mathf.Abs(car.slipVelo) * 0.15f - 0.95f);
        skidSource.volume = skidVol >= 0.3f ? skidVol : 0f;

        transmissionOnSource.pitch = 0.20f + drivetrain.rpm / drivetrain.maxRPM;

        transmissionOffSource.pitch = 0.20f + drivetrain.rpm / drivetrain.maxRPM;

        blowOffValveSource.pitch = 0.28f + drivetrain.rpm / drivetrain.maxRPM;

        currSpeed = (int)(GetComponent<Rigidbody>().velocity.magnitude * 3.6f);

        // sound generated when slowing down
        if (currSpeed > (lastSpeed + 3)) { // speeding up
            lastSpeed = currSpeed;
            //high
            transmissionOffSource.volume -= 0.10f;

            if (transmissionOffSource.volume == 0f) {
                transmissionOffSource.Stop();
            }
        } else if ((float)currSpeed < (float)((float)lastSpeed - 3.2f)) { //slowing down
            lastSpeed = currSpeed;
            //low
            transmissionOffSource.volume = 0.05f;

            if (!transmissionOffSource.isPlaying) {
                transmissionOffSource.Play();
            }
        }
    }
}
