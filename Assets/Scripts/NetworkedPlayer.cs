using UnityEngine;
using System.Collections;

public class NetworkedPlayer : Photon.MonoBehaviour
{
	public GameObject avatar;
	
	public Transform playerGlobal;
	public Transform playerLocal;
	
	void Start ()
	{
		Debug.Log("i'm instantiated");
		
		if (photonView.isMine)
		{
			Debug.Log("player is mine");

			GameObject.Find("CardboardMain").transform.Translate(Random.Range(-4.0F, 4.0F), 0, Random.Range(-4.0F, 4.0F));

			playerGlobal = GameObject.Find("CardboardMain").transform;
			playerLocal = playerGlobal.Find("Head");
			
			this.transform.SetParent(playerLocal);
			this.transform.localPosition = Vector3.zero;
			
			//avatar.SetActive(false);
		}
	}
	
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext(playerGlobal.position);
			stream.SendNext(playerGlobal.rotation);
			stream.SendNext(playerLocal.localPosition);
			stream.SendNext(playerLocal.localRotation);
		}
		else
		{
			this.transform.position = (Vector3)stream.ReceiveNext();
			this.transform.rotation = (Quaternion)stream.ReceiveNext();
			avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
			avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();
		}
	}
}