using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CircleSkript : MonoBehaviour
{
    public Rigidbody2D _rb2D;

    public float Speed;

    public LineRenderer _line;

    public bool inFirst = true;

    public TMP_Text _forseCount;

    public GameObject looseCanv;
    public GameObject atherCanvas;

    public GameObject ArrowPref;
    public GameObject Arrow;

    private float Timer = 5;

    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (inFirst)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    OnTypeBegan();
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    OnType(touch);
                }

                else if (touch.phase == TouchPhase.Ended)
                {
                    OnStopType(touch);
                }
            }
        }

        if (!inFirst)
        {
            if(Timer <= 0)
            {
                if ((Aaa(_rb2D.velocity.x) <= 0.5 && Aaa(_rb2D.velocity.y) <= 0.5) && !inFirst) OnLoose();
            }
            else
            {
                Timer -= Time.deltaTime;
            }
        }
    }

    void OnTypeBegan()
    {
        Arrow = Instantiate(ArrowPref);
    }

    void OnType(Touch touch)
    {
        Vector3 touchPos = touch.position;

        Vector2 dir = touchPos - Camera.main.WorldToScreenPoint(transform.position);

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Arrow.transform.position = Camera.main.ScreenToWorldPoint(touchPos);
        Arrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        RenderLine(Camera.main.ScreenToWorldPoint(touchPos));
        
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnStopType(Touch touch)
    {
        float _speed;
        _speed = Vector2.Distance(touch.position, transform.position);

        _rb2D.AddRelativeForce(new Vector2(0, _speed * Speed));
        RenderLine(transform.position);
        _forseCount.text = "";
        inFirst = false;
        Destroy(Arrow);
    }

    void RenderLine(Vector3 touchPos)
    {
        _forseCount.text = Math.Round(Vector2.Distance(touchPos, transform.position), 1).ToString();

        _line.SetPosition(0, transform.position);
        _line.SetPosition(1, new Vector3(touchPos.x, touchPos.y, 0));
    }

    void OnLoose()
    {
        looseCanv.SetActive(true); atherCanvas.SetActive(false);
    }

    float Aaa(float flVair)
    {
        if(flVair < 0)
        {
            flVair *= -1;
        }
        return flVair;
    }
}
