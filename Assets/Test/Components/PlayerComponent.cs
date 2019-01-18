//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//2019年01月18日03:46:58
//Assembly-CSharp

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using MagicOnion.Client;
using MagicOnionTestService.LobbyMessageTest;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlayerComponent:MonoBehaviour,IPlayer
    {
        private static PlayerComponent _playerComponent;
       public static PlayerComponent Ins
       {
           get
           {
               if (!_playerComponent)
               {
                   _playerComponent = GameObject.FindObjectOfType<PlayerComponent>();
               }

               return _playerComponent;
           }
       }
        
        public  PlayerInfo info;
        
        private IPlayerHub _playerHub;
        private bool _isJoin;
        
        private void Start()
        {
            this._isJoin = false;
            
            _playerHub = StreamingHubClient.Connect<IPlayerHub, IPlayer>(RoomComponent.Channel, this);
        }

        #region Client -> Server

        public async void JoinRoom(string roomName)
        {
            await this._playerHub.JoinAsync(roomName,info);
            this._isJoin = true;
        }
        
        public async void LeaveRoom()
        {
            await this._playerHub.LeaveAsync();
            this._isJoin = false;
        }

        /// <summary>
        /// 加入房间或退出房间
        /// </summary>
//        public async void JoinOrLeave()
//        {
//            if (this._isJoin)
//            {
//                LeaveRoom();
////                this.JoinOrLeaveButtonText.text = "加入房间";
////                this.SendMessageButton.gameObject.SetActive(false);
////                UserNameInputField.gameObject.SetActive(true);
//            }
//            else
//            {
////                if (string.IsNullOrEmpty(UserNameInputField.text))
////                {
////                    this.ChatText.text += $"<color=\"red\">用户名不能为空..</color>";
////                    return;
////                }
////                JoinRoom();
////                this.JoinOrLeaveButtonText.text = "离开房间";
////                this.SendMessageButton.gameObject.SetActive(true);
////                UserNameInputField.gameObject.SetActive(false);
//            }
//        }
        private Vector3 _lastPos;
        private async void _move()
        {
            if (!_isJoin)
            {
                return;
            }

            if (Vector3.Distance(_lastPos,transform.position) <= 0.1f)
            {
                return;
            }

            _lastPos = transform.position;
            
            await this._playerHub.MoveAsync(PlayerInfo.ID,new Ve3()
            {
                X = transform.position.x,
                Y = transform.position.y,
                Z = transform.position.z
            });
        }
        #endregion

        private void FixedUpdate()
        {
            _move();
        }

        Dictionary<Guid,GameObject> _otherPlayer = new Dictionary<Guid, GameObject>();
        public void OnJoin(PlayerInfo playerInfo)
        {
            GameObject go = Instantiate(Resources.Load<GameObject>("Player"));

            if (playerInfo.ID != playerInfo.ID)
            {
                _otherPlayer.Add(playerInfo.ID,go);
            }
            else
            {
                go.AddComponent<MoveComponent>();
            }
        }

        public Task JoinAsync(string roomName, PlayerInfo playerInfo)
        {
            throw new System.NotImplementedException("客户端无需关心");
        }

        public void OnLeave(PlayerInfo playerInfo)
        {
            Destroy(_otherPlayer[playerInfo.ID]);

            if (playerInfo.ID != playerInfo.ID)
            {
                _otherPlayer.Remove(playerInfo.ID);
            }
            else
            {
                PlayerInfo = null;
            }
        }

        public Task LeaveAsync()
        {
            throw new System.NotImplementedException("客户端无需关心");
        }

        public void OnMove(Guid id, Ve3 newPosition)
        {
            if (id != PlayerInfo.ID)
            {
                _otherPlayer[id].transform.position = new Vector3(newPosition.X,newPosition.Y,newPosition.Z);
            }
        }

        public Task MoveAsync(Guid id, Ve3 newPosition)
        {
            throw new System.NotImplementedException("客户端无需关心");
        }

        public PlayerInfo PlayerInfo { get; private set; }
    }
}