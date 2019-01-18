//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//2019年01月16日05:07:11
//Assembly-CSharp

using System;
using System.Threading.Tasks;
using Grpc.Core;
using MagicOnion.Client;
using MagicOnionTestService.LobbyMessageTest;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class RoomComponent:MonoBehaviour
    {
        public GameObject RoomContent;

        public InputField RoomInputField;

        public InputField UserNameInputField;

        public static Channel Channel;

        private void Awake()
        {
            Channel = new Channel("localhost:12345", ChannelCredentials.Insecure);
        }

        
        private void Start()
        {
            var getRoom = MagicOnionClient.Create<IGetRoomList>(Channel);
            _updateRoom(getRoom);
        }
        
        private async Task _updateRoom(IGetRoomList getRoom)
        {
            var rooms = await getRoom.GetAllRoom();
            
            foreach (var room in rooms)
            {
                var button = new GameObject(room).AddComponent<Button>();
                var text = button.GetComponentInChildren<Text>();
                text.text = $"Join {room} Room";
                text.fontSize = 40;
                var butRectT = (RectTransform) button.transform;
                butRectT.sizeDelta = new Vector2(200,60);
                button.onClick.AddListener(() => { PlayerComponent.Ins.JoinRoom(room); });
                button.transform.SetParent(RoomContent.transform);
            }
        }

        public void CreatePlayer()
        {
            if (!UserNameInputField || string.IsNullOrWhiteSpace(UserNameInputField.text))
            {
                return;
            }
            
            PlayerComponent.Ins.PlayerInfo.Name = UserNameInputField.text;
            PlayerComponent.Ins.PlayerInfo.ID = Guid.NewGuid();   
        }

        public void JoinRoom()
        {
            if (!RoomInputField || string.IsNullOrWhiteSpace(RoomInputField.text))
            {
                return;
            }
            
            if (PlayerComponent.Ins.PlayerInfo == null)
            {
                CreatePlayer();
            }

            PlayerComponent.Ins.JoinRoom(RoomInputField.text); 
        }
    }
}