using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
///  パーティクルのプーリング用クラス
/// </summary>
public class ParticlePooler{
    public ParticlePooler(string particleName)
    {
        this.particleName = "Effects/" + particleName;
    }
    //キーの指定があった場合
    public ParticlePooler(string particleName,string objName)
    {
        this.particleName = "Effects/" + particleName;
        this.objectName = objName;
    }

    /// <summary>
    /// パーティクル名
    /// </summary>
    private string particleName;
	public string ParticleName{
		get {return particleName;}
        set { this.particleName = value;  }
    }


    //オブジェクト名変更
    private string objectName;
    public string ObjectName
    {
        get { return objectName; }
        set { this.objectName = value; }
    }




	/// <summary>
	/// パーティクルを保持しておくリスト
	/// </summary>
	private List<ParticleSystem> particleList = new List<ParticleSystem>();
	public List<ParticleSystem> ParticleList{
		get { return particleList;}
	}

	/// <summary>
	/// 生成元のパーティクル
	/// </summary>
	private GameObject particleOrigin = null;

	/// <summary>
	/// 指定の座標で再生
	/// </summary>
	/// <param name="position">Position.</param>
    /// 

    //指定座標表示
	public void Play(Vector3 position){
		ParticleSystem particle = GetPlayableParticle();
		if(particle == null){
			particle = InstantiateParticle();
            Debug.Log("パーティクル生成");
        }
		particle.transform.position = position;
		particle.Play();
	}

    //親オブジェクトを指定
    public void Play(string name)
    {
        GameObject obj;
        obj = GameObject.Find(name);

        ParticleSystem particle = GetPlayableParticle();
        if (particle == null)
        {
            particle = InstantiateParticle();
            Debug.Log("パーティクル生成");
        }
        particle.transform.position = obj.transform.position;
        particle.transform.parent = obj.transform;
        particle.Play();
    }

    //停止
    public void Stop()
    {
        ParticleSystem particle = GetPlayableParticle();
        if (particle == null)
        {
            particle = InstantiateParticle();
        }
        particle.Stop();
    }


    /// <summary>
    /// 再生可能なパーティクルを取得
    /// </summary>
    /// <returns>再生可能なパーティクル.</returns>
    private ParticleSystem GetPlayableParticle(){
		return particleList.Where(particle => !particle.isPlaying).FirstOrDefault();
	}

	/// <summary>
	/// パーティクル生成
	/// </summary>
	/// <returns>The particle.</returns>
	private ParticleSystem InstantiateParticle(){
		LoadOrigin();
		GameObject particleGO = GameObject.Instantiate(particleOrigin) as GameObject;
        if (objectName != null)
        {
            //キーをタグに追加
            particleGO.name = objectName;
            TagHelper.AddTag(objectName);
            particleGO.tag = objectName;
        }
        else
        {
            particleGO.name = particleName;
        }
        ParticleSystem particle = particleGO.GetComponent<ParticleSystem>();
		particleList.Add(particle);
		return particle;
	}

	/// <summary>
	/// 生成元のオブジェクトをロード
	/// </summary>
	private void LoadOrigin(){
		if(particleOrigin == null){
			particleOrigin = Resources.Load(particleName) as GameObject;
		}
	}

	/// <summary>
	/// 破棄時処理
	/// </summary>
	private void Clean(){
		particleList.Clear();
		particleList = null;
		particleOrigin = null;
	}
}