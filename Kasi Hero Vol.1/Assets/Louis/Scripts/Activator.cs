using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

    public KeyCode key;
    public KeyCode MainKey;
    public bool active = false;
    GameObject note;
    SpriteRenderer sr;
    Color old;

    public GameManager gm;

    public bool createMode;
    public GameObject n;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        old = sr.color;
    }
    // Update is called once per frame
    void Update()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(key))
            {
                Instantiate(n, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(key) || Input.GetKeyDown(MainKey))
            {
                StartCoroutine(Pressed());
            }
            if ((Input.GetKeyDown(key) || Input.GetKeyDown(MainKey)) && active)
            {
                if (active)
                {
                    //Destroy(note);
                    note.SetActive(false);
                }
            }
        }
        }

        void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if (col.gameObject.tag == "Note")
        {
            note = col.gameObject;
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        active = false;

        if (!note.activeSelf)
        {
            gm.NoteHit();
        }
        else
        {
            gm.NoteMissed();
        }
    }
    IEnumerator Pressed()
    {
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
    }


}
