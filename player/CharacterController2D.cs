using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;                          // forta adaugata cand jucatorul sare
	[SerializeField] private float m_DoubleJumpForce = 250f;                    // forta adaugata cand jucatorul face o saritura dubla
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // cat de continua sa arate miscarea
	[SerializeField] private bool m_AirControl = false;                         // jucatorul poate sau nu sa controleze miscarea cat este in aer
	[SerializeField] private LayerMask m_WhatIsGround;                          // detecteaza ce este "ground"
	[SerializeField] private Transform m_GroundCheck;                           // o pozitie ce marcheaza unde sa se verifice daca jucatorul este pe pamant
	[SerializeField] private Transform m_CeilingCheck;                          // o pozitie ce marcheaza unde sa se verifice pentru "tavan"

	const float k_GroundedRadius = .2f; // ajuta sa se determine daca jucatorul este pe pamant
	private bool m_Grounded;            // jucatorul este sau nu pe pamant
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // pentru a determina in ce directie se uita jucatorul (stanga/dreapta)
	private Vector3 m_Velocity = Vector3.zero;
	bool doubleJump = true; // variabila ce va permire saritura dubla cand este = true

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent; // eveniment ce este activat cand jucatorul aterizeaza

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// jucatorul este pe pamant daca orice punct din collider-ul pentru ground check (care este rotund) atinge orice obiect care a fost desemnat drept pamant
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				// daca nu este pe pamant se invoca evenimentul de aterizare
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

	public void Move(float move, bool jump)
	{

		// controleaza jucatorul doar daca este pe pamant sau variabila airControl este true
		if (m_Grounded || m_AirControl)
		{

			// misca jucatorul in directia si viteza indicata de move
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// Face miscarea mai lina si aplica aceasta modificare jucatorului
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// daca variabila move indica deplasarea spre dreapta, iar personajul se uita catre stanga
			if (move > 0 && !m_FacingRight)
			{
				// schimba orientarea personajului catre dreapta
				Flip();
			}
			// daca variabila move indica deplasarea spre stanga, iar personajul se uita catre dreapta
			else if (move < 0 && m_FacingRight)
			{
				// schimba orientarea personajului catre stanga
				Flip();
			}
		}

		// daca jucatorul nu este pe pamant, dar doreste sa sara se va verifica daca doubleJump = true si va executa sau nu saritura dubla
		if(!m_Grounded && jump && doubleJump)
		{
			// dupa ce s-a efectuat saritura dubla aceasta se reseteaza la false pentru ca jucatorul sa nu poata efectua o saritura tripla etc...
			doubleJump = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_DoubleJumpForce));

		}

		// daca jucatorul doreste sa sara si este pe pamant
		if (m_Grounded && jump)
		{
			// adauga o forta verticala acestuia
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			// intrucat jucatorul era pe pamant, inseamna ca a efectuat o saritura simpla deci are dreptul la o saritura dubla
			doubleJump = true;
		}
	}


	private void Flip()
	{
		// declara directia in care este orientat jucatorul ca fiind opusa celei de pana acum
		m_FacingRight = !m_FacingRight;

		// schimba efectiv orientarea jucatorului inmultind cu -1
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
