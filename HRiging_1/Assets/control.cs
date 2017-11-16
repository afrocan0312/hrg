using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour {
	public GameObject temp;
	public float velocity = 0.7f;
	private Transform _transform;
	private bool _isJumping;
	private float _posY;        //오브젝트의 초기 높이
	private float _gravity;     //중력가속도
	private float _jumpPower;   //점프력
	private float _jumpTime;    //점프 이후 경과시간
	private GameObject currentButton;
	public int score=0;
	public Text ShowScore;
	private Clicker clicker = new Clicker ();



	//출처: http://tenlie10.tistory.com/124 [게임 개발자 블로그]
	// Use this for initialization
	void Start () {
		_transform = transform;
		_isJumping = false;
		_posY = transform.position.y;
		_gravity = 9.8f;
		_jumpPower = 4.0f;
		_jumpTime = 0.5f;


		//출처: http://tenlie10.tistory.com/124 [게임 개발자 블로그]
	}

	// Update is called once per frame
	void Update () {

		ShowScore.text = "" + score;

		Vector3 moveDirection = Camera.main.transform.forward;
		moveDirection *= velocity * Time.deltaTime;
		transform.position += moveDirection;

		if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
		{
			_isJumping = true;
			_posY = _transform.position.y;
			score++;
		}

		if (_isJumping)
		{
			Jump();

		}

		/*GameObject hitButton = null;
		currentButton = hitButton;
		if (currentButton = null) {
			_isJumping = true;
			_posY = _transform.position.y;
			Jump();
			}*/
		}

		//출처: http://tenlie10.tistory.com/124 [게임 개발자 블로그]

	
	void Jump()
	{
		//y=-a*x+b에서 (a: 중력가속도, b: 초기 점프속도)
		//적분하여 y = (-a/2)*x*x + (b*x) 공식을 얻는다.(x: 점프시간, y: 오브젝트의 높이)
		//변화된 높이 height를 기존 높이 _posY에 더한다.
		float height = (_jumpTime * _jumpTime * (-_gravity) / 2) + (_jumpTime * _jumpPower);
		_transform.position = new Vector3(_transform.position.x, _posY + height, _transform.position.z);
		//점프시간을 증가시킨다.
		_jumpTime += Time.deltaTime;


		//처음의 높이 보다 더 내려 갔을때 => 점프전 상태로 복귀한다.
		if (height < 0.0f)
		{
			_isJumping = false;
			_jumpTime = 0.0f;
			_transform.position = new Vector3(_transform.position.x, _posY, _transform.position.z);
		}
	}


	//출처: http://tenlie10.tistory.com/124 [게임 개발자 블로그]


	}

