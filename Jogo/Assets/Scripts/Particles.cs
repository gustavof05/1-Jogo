
using System.Runtime.Serialization;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Particles : MonoBehaviour
{
    public GameObject _player;
    public GameObject botao;
    public GameObject[] botoes;

    [SerializeField]
    private GameObject _object;

    public void Spawn()
    {
        Instantiate(_object, transform.position, Quaternion.identity);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject == _player)
        {
            foreach (GameObject botao in botoes)
            {
                Instantiate(_object, botao.transform.position, Quaternion.identity);
            }
        }
    }
}
