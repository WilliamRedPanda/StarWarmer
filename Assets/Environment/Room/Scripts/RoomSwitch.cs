using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using StateMachine.Gameplay;

[RequireComponent(typeof(BoxCollider))]
public class RoomSwitch : MonoBehaviour
{
    const float PLAYER_MOVEMENT_OFFSET = 3.5f;
    
    [HideInInspector] public bool roomFinished;

    #region Serialized
    public CameraShake cameraShake;
    [SerializeField] GameplaySM gameplaySM;
    //[Space]
    //[SerializeField] GameObject objectToActive;
    [Space]
    [SerializeField] bool finalRoom;
    [Space]
    [SerializeField] GameObject doorNorth;
    [SerializeField] GameObject doorSouth;
    //[SerializeField] GameObject doorEst;
    //[SerializeField] GameObject doorWest; 
    #endregion


    [HideInInspector] public List<GenericEnemy> enemies;

    private void Awake()
    {
        enemies = new List<GenericEnemy>();
        roomFinished = true;
        //objectToActive.SetActive(false);
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        SetEnemy(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        GenericEnemy enemy = other.GetComponentInParent<GenericEnemy>();
        if (enemy)
        {
            enemies.Add(enemy);
            enemy.OnDeath += CheckEnemies;
            if (roomFinished)
            {
                roomFinished = false;
                CloseRoom();
            }
        }

        PlayerData player = other.gameObject.GetComponentInParent<PlayerData>();
        if (player)
        {
            //objectToActive.SetActive(true);
            SetEnemy(true);
            cameraShake.SetPlayer(player);
            CameraManager.ChangeCamera(this);
            if (finalRoom && enemies.Count == 0)
            {
                gameplaySM.Go("Win");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerData player = other.gameObject.GetComponentInParent<PlayerData>();
        if (player)
        {
            SetEnemy(false);
        }
    }

    void CheckEnemies(IDamageable damageable)
    {
        enemies.Remove(damageable as GenericEnemy);
        if (enemies.Count == 0)
        {
            OpenRoom();
        }
    }

    void OpenRoom()
    {
        roomFinished = true;
        if (doorNorth)
            doorNorth.SetActive(false);
        if (doorSouth)
            doorSouth.SetActive(false);
        //if (doorEst)
        //    doorEst.SetActive(false);
        //if (doorWest)
        //    doorWest.SetActive(false);
    }

    void CloseRoom()
    {
        if (doorNorth)
            doorNorth.SetActive(true);
        if (doorSouth)
            doorSouth.SetActive(true);
        //if (doorEst)
        //    doorEst.SetActive(true);
        //if (doorWest)
        //    doorWest.SetActive(true);
    }

    public void ChangeRoom(PlayerData player, DoorTrigger.DoorDirection door)
    {
        switch (door)
        {
            case DoorTrigger.DoorDirection.north:
                MovePlayer(Vector3.forward, player);
                break;
            case DoorTrigger.DoorDirection.south:
                MovePlayer(Vector3.back, player);
                break;
            case DoorTrigger.DoorDirection.west:
                MovePlayer(Vector3.left, player);
                break;
            case DoorTrigger.DoorDirection.east:
                MovePlayer(Vector3.right, player);
                break;
            default:
                break;
        }
    }

    IEnumerator SetFalseRoom()
    {
        yield return new WaitForSeconds(2f);
        //objectToActive.SetActive(false);
        SetEnemy(false);
    }

    void MovePlayer(Vector3 direction, PlayerData player)
    {
        player.transform.position += direction * PLAYER_MOVEMENT_OFFSET;
    }

    void SetEnemy(bool _active)
    {
        int l = enemies.Count;
        for (int i = 0; i < l; i++)
        {
            enemies[i].gameObject.SetActive(_active);
        }
    }
}