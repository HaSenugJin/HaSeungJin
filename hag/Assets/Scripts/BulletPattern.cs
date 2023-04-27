using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletPattern : MonoBehaviour
{
    public enum Pattern
    {
        screw, DelayScrew, Twist, D, Explosion, F, GuideBullet
    };

    public Pattern pattern = Pattern.Explosion;
    public Sprite sprite;
    private List<GameObject> BulletList = new List<GameObject>();
    private string BulletPrefab = "PattrenBullet";
    
    void Start()
    {
        

        switch (pattern)
        {
            case Pattern.screw:
                GetscrewPattern(5.0f, (int)(360 / 5.0f));
                break;

            case Pattern.DelayScrew:
                StartCoroutine(GetDelayScrewPattern());
                break;

            case Pattern.Twist:
                StartCoroutine(TwistPattern());
                break;

            case Pattern.D:

                break;

            case Pattern.Explosion:
                StartCoroutine(ExplosionPattern(5.0f, (int)(360 / 5.0f)));
                break;

            case Pattern.F:

                break;

            case Pattern.GuideBullet:
                GuideBulletPattern();
                break;
        }
    }

    void Update()
    {
       
    }

    private void GetscrewPattern(float _angle, int _count, bool _option = false)
    {
        for(int i = 0; i < _count; ++i)
        {
            GameObject obj = Instantiate(pre.GetInstence.getPrefnbByName(BulletPrefab));
            BulletControll controller = obj.GetComponent<BulletControll>();
            controller.Option = _option;
            _angle += 5.0f;
            controller.Direction = new Vector3(
                Mathf.Cos(_angle * Mathf.Deg2Rad),
                Mathf.Sin(_angle * Mathf.Deg2Rad),
                0.0f) * 5 + transform.position;

            obj.transform.position = transform.position;

            BulletList.Add(obj);
        }
    }

    private IEnumerator GetDelayScrewPattern()
    {
        float fAngle = 30.0f;

        int iCount = (int)(360 / fAngle);

        int i = 0;

        while(i < (iCount) *3)
        {
            GameObject obj = Instantiate(pre.GetInstence.getPrefnbByName(BulletPrefab));

            BulletControll controller = obj.GetComponent<BulletControll>();

            controller.Option = false;

            fAngle += 30.0f;

            controller.Direction = new Vector3(
                Mathf.Cos(fAngle * Mathf.Deg2Rad),
                Mathf.Sin(fAngle * Mathf.Deg2Rad),
                0.0f) * 5 + transform.position;

            obj.transform.position = transform.position;

            BulletList.Add(obj);
            ++i;
            yield return new WaitForSeconds(0.02f);
        }   
    }

    private IEnumerator TwistPattern()
    {
        float fTime = 3.0f;
        while(fTime>0)
        {
            fTime -= Time.deltaTime;
            GameObject obj = Instantiate(Resources.Load("Prefabs/Twist")) as GameObject;
            yield return null;
        }
    }

    public IEnumerator ExplosionPattern(float _angle, int _count, bool _option = false)
    {
        GameObject parentobj = new GameObject("Bullet");
        //parentobj.AddComponent<MyGizmo>();
        SpriteRenderer renderer = parentobj.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;

        BulletControll controll = parentobj.AddComponent<BulletControll>();

        controll.Option = false;

        controll.Direction = GameObject.Find("Target").transform.position - transform.position;

        parentobj.transform.position = transform.position;

        yield return new WaitForSeconds(1.5f);

        Vector3 pos = parentobj.transform.position;

        Destroy(parentobj);

        for (int i = 0; i < _count; ++i)
        {
            GameObject obj = Instantiate(pre.GetInstence.getPrefnbByName(BulletPrefab));
            BulletControll controller = obj.GetComponent<BulletControll>();
            controller.Option = _option;
            _angle += 5.0f;
            controller.Direction = new Vector3(
                Mathf.Cos(_angle * Mathf.Deg2Rad),
                Mathf.Sin(_angle * Mathf.Deg2Rad),
                0.0f) * 5 + transform.position;

            obj.transform.position = pos;

            BulletList.Add(obj);
        }
    }

    public void GuideBulletPattern()
    {
        GameObject obj = Instantiate(pre.GetInstence.getPrefnbByName(BulletPrefab));

        BulletControll controller = obj.GetComponent<BulletControll>();

        controller.Target = GameObject.Find("Target");
        controller.Option = true;

        obj.transform.position = transform.position;
    }
}
