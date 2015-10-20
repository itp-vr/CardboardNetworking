using UnityEngine;
using System.Collections;


public class NetworkController : MonoBehaviour
{
	string _room = "Cardboard_Networking";
	
	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
		Debug.Log ("Connected");


	}
	
	void OnJoinedLobby()
	{
		Debug.Log("joined lobby");
		
		RoomOptions roomOptions = new RoomOptions() { };
		PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
	}
	

	void OnJoinedRoom()
	{

		//PhotonNetwork.Instantiate("CardboardMain", new Vector3(Random.Range(-5.0F, 5.0F), 0, Random.Range(-5.0F, 5.0F)), Quaternion.identity, 0);
		PhotonNetwork.Instantiate("NetworkedPlayer", Vector3.zero, Quaternion.identity, 0);
	}
}