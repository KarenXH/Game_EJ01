using System.Collections;
using UnityEngine;

public class Warning : MonoBehaviour
{
    [SerializeField] protected GameObject _target;
    [SerializeField] protected GameObject _spawn;
    [SerializeField] protected GameObject _gamePlayDialog;
    [SerializeField] protected GameObject _pauseDialog;
    [SerializeField] protected GameObject _gameoverDialog;
    [SerializeField] protected bool _isPlaying = false;

    private void Start()
    {
        StartCoroutine(this.SpawnWarning());
    }

    void FixedUpdate()
    {
        this.CheckGameplaying();        
    }
    

    protected void CheckGameplaying()
    {
        if (_gamePlayDialog.activeSelf == false || _pauseDialog.activeSelf == true || _gameoverDialog.activeSelf == true) 
        {
            _isPlaying = false;
            return;
        }        
        _isPlaying = true;
        
    }

 
    IEnumerator SpawnWarning()
    {
        if (_isPlaying == true && GameManager.Ins.Score > 200)
        {
            Vector3 pos = new Vector3(_target.transform.position.x, this.gameObject.transform.position.y -0.7f, this.gameObject.transform.position.z);
             GameObject warning = Instantiate(_spawn, pos, Quaternion.identity);
            
            warning.transform.SetParent(this.gameObject.transform);
            yield return new WaitForSeconds(15f);
        }

        if (_isPlaying == true && GameManager.Ins.Score > 1000)
        {
            Vector3 pos = new Vector3(_target.transform.position.x, this.gameObject.transform.position.y - 0.7f, this.gameObject.transform.position.z);
            GameObject warning = Instantiate(_spawn, pos, Quaternion.identity);

            warning.transform.SetParent(this.gameObject.transform);
            yield return new WaitForSeconds(10f);
        }

        if (_isPlaying == true && GameManager.Ins.Score > 1500)
        {
            Vector3 pos = new Vector3(_target.transform.position.x, this.gameObject.transform.position.y - 0.7f, this.gameObject.transform.position.z);
            GameObject warning = Instantiate(_spawn, pos, Quaternion.identity);

            warning.transform.SetParent(this.gameObject.transform);
            yield return new WaitForSeconds(6f);
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(this.SpawnWarning());
    }

}
