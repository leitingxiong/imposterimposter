using UnityEngine;
public class Laddar : MonoBehaviour
{
    //闂傚倸鍊峰ù鍥р枖閺囥垹绐楅柟鐗堟緲閸戠姴鈹戦悩瀹犲缂佺媭鍨抽埀顒傛嚀鐎氼厽绔熼崱娆戠煋闁秆勵殕閳锋垿鎮归幁鎺戝闁哄鍨块弻锛勨偓锝庝憾閻撳吋顨ラ悙鑼闁诡喗绮撻幊鐐哄Ψ閿旂瓔浠ч梻鍌欑閹碱偊宕愰崼鏇炵９闁哄稁鍋€閸嬫挸顫濋鍌溞ㄩ梺鍝勮閸旀垿骞冮姀銈呯閻忓繑鐗楅悗閬嶆煟閻斿摜鐭嬪鐟邦儔瀵彃饪伴崼婵婂煘婵犵數濮甸懝鍓х不椤栫偞鐓熼柟杈剧到琚氶梺鍝勬噹閹芥粎妲愰幒妤€鐭楀璺猴工椤帡姊烘潪鎵妽闁圭懓娲ら锝夘敆閸曨倠褔鏌涢埄鍐炬濞村吋鎹囧缁樻媴閼恒儳銆婇梺鍝ュУ閸旀瑥顕ｉ崨濠勭瘈婵﹩鍓涢鍡涙⒑缂佹ê鐏卞┑顔哄€濆鏌ュ箹娴ｅ湱鍘搁梺绋挎湰閿氶柍褜鍓氶悧婊堝焵椤掍胶鍟查柟鍑ゆ嫹
    private float playerPositon_Y;

    //闂傚倸鍊峰ù鍥р枖閺囥垹绐楅柟鐗堟緲閸戠姴鈹戦悩瀹犲缂佺媭鍨堕弻锝夊箣閿濆憛鎾绘煛閸涱喗鍊愮€殿喖鐖奸幃娆戜沪閸屾瑧閽电紓鍌欑窔绾悂宕抽敐澶屽祦闊洦绋掗崐濠氭煠閹帒鍔滄繛鍛灲濮婅櫣鎹勯妸銉︾彚闂佺懓鍤栭幏锟�
    private Transform player_transform;
    public RoleEntity roleEntity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out roleEntity))
        {
            player_transform = collision.transform;
            roleEntity.playerPositon_Y = GetComponent<BoxCollider2D>().size.y + transform.position.y + 3f;
            roleEntity.rb.gravityScale = 0;
            if (playerPositon_Y > transform.position.y)  //闂傚倸鍊峰ù鍥р枖閺囥垹绐楅柟鐗堟緲閸戠姴鈹戦悩瀹犲缂佺媭鍨堕弻锝夊箣閿濆憛鎾绘煛閸涱喗鍊愰柡宀嬬節瀹曟帒螣鐞涒€充壕闁哄稁鍋€閸嬫挸顫濋鍌溞ㄩ梺鍝勮閸旀垿骞冮姀銈呭窛濠电姴瀚槐鏇㈡⒒娴ｅ摜绉烘い銉︽崌瀹曟顫滈埀顒€顕ｉ锕€绠婚悹鍥у级椤ユ繈姊洪棃娑氬婵☆偅顨婇、鏃堝醇閺囩啿鎷洪柣鐘充航閸斿矂寮搁幋锔界厸閻庯綆浜堕悡鍏碱殽閻愯尙绠婚柟顔界矒閹崇偤濡烽敂绛嬩户闂傚倷绀侀幖顐﹀磹閸洖纾归柡宥庡亐閸嬫挸顫濋幇浣圭秷婵烇絽娲ら敃顏堛€侀弴銏╂晝闁靛繒濮幐鍕⒒娴ｅ摜绉烘い銉︽崌瀹曟顫滈埀顒€顕ｉ锕€绠婚悹鍥у级椤ユ繈姊洪棃娑氬婵☆偅顨婇、鏃堝醇閺囩啿鎷洪柣鐘充航閸斿矂寮搁幋锔界厸閻庯綆浜堕悡鍏碱殽閻愯尙绠婚柟顔界矒閹崇偤濡烽敂绛嬩户闂傚倷绀侀幖顐﹀磹閸洖纾归柡宥庡亐閸嬫挸顫濋鍌溞ㄩ梺鍝勮閸旀垿骞冮姀銈呯閻忓繑鐗楅悗閬嶆⒒娴ｅ憡鍟為悽顖滃仧娴滄悂濡搁埡浣侯唵闂佽法鍣﹂幏锟�
                roleEntity.climbing = RoleEntity.Climbing.Down;
            if (playerPositon_Y < transform.position.y)  //闂傚倸鍊峰ù鍥р枖閺囥垹绐楅柟鐗堟緲閸戠姴鈹戦悩瀹犲缂佺媭鍨堕弻锝夊箣閿濆憛鎾绘煛閸涱喗鍊愰柡宀嬬節瀹曟帒螣鐞涒€充壕闁哄稁鍋€閸嬫挸顫濋鍌溞ㄩ梺鍝勮閸旀垿骞冮姀銈呭窛濠电姴瀚槐鏇㈡⒒娴ｅ摜绉烘い銉︽崌瀹曟顫滈埀顒€顕ｉ锕€绠婚悹鍥у级椤ユ繈姊洪棃娑氬婵☆偅顨婇、鏃堝醇閺囩啿鎷洪柣鐘充航閸斿矂寮搁幋锔界厸閻庯綆浜堕悡鍏碱殽閻愯尙绠婚柟顔界矒閹崇偤濡烽敂绛嬩户闂傚倷绀侀幖顐﹀磹閸洖纾归柡宥庡亐閸嬫挸顫濋幇浣圭秷婵烇絽娲ら敃顏堛€侀弴銏╂晝闁靛繒濮幐鍕⒒娴ｅ摜绉烘い銉︽崌瀹曟顫滈埀顒€顕ｉ锕€绠婚悹鍥у级椤ユ繈姊洪棃娑氬婵☆偅顨婇、鏃堝醇閺囩啿鎷洪柣鐘充航閸斿矂寮搁幋锔界厸閻庯綆浜堕悡鍏碱殽閻愯尙绠婚柟顔界矒閹崇偤濡烽敂绛嬩户闂傚倷绀侀幖顐﹀磹閸洖纾归柡宥庡亐閸嬫挸顫濋鍌溞ㄩ梺鍝勮閸旀垿骞冮姀銈呯閻忓繑鐗楅悗閬嶆⒒娴ｅ憡鍟為悽顖滃仧娴滄悂濡搁埡浣侯唵闂佽法鍣﹂幏锟�
                roleEntity.climbing = RoleEntity.Climbing.Up;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out roleEntity))
        {
        roleEntity.climbing = RoleEntity.Climbing.Out;
        roleEntity.rb.gravityScale = 5;
        }
    }

}
