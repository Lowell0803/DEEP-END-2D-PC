using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] crescentSlashes;
    [SerializeField] private AudioClip crescentslashSound;
    [SerializeField] private AudioClip crescentslashesSound;
    [SerializeField] private AudioClip crescentslashesAfterSound;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    [SerializeField] private float skillCooldown = 3f;
    private float skillcooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown && playerMovement.canAttack()) {
            
            Attack();
        }


        if (Input.GetKeyDown(KeyCode.E) && skillcooldownTimer > skillCooldown && playerMovement.canSkill())
        {
            Skill();
        }

        
        cooldownTimer += Time.deltaTime;
        skillcooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(crescentslashSound);
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        print("attacking!");


    }

    private void Skill()
    {
        SoundManager.instance.PlaySound(crescentslashesSound);
        anim.SetTrigger("skill");
        skillcooldownTimer = 0;
        
    }

    public void CreateSlashForBasic()
    { 
        crescentSlashes[FindCrescentSlash()].transform.position = firePoint.position;
        crescentSlashes[FindCrescentSlash()].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));
    }

    public void CreateSlash()
    {
        SoundManager.instance.PlaySound(crescentslashesAfterSound);
        crescentSlashes[FindCrescentSlash()].transform.position = firePoint.position;
        crescentSlashes[FindCrescentSlash()].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindCrescentSlash()
    {
        for (int i = 0; i < crescentSlashes.Length; i++)
        {
            if (!crescentSlashes[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
