using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class ParticleManager{

	/// <summary>
	/// プール用オブジェクトのリスト
	/// </summary>
	private static List<ParticlePooler> particlePoolerList = new List<ParticlePooler>();
    
    /// <summary>
    /// 指定した名前のパーティクル再生
    /// 	初めて再生するパーティクルはプール用オブジェクトを生成
    /// </summary>
    /// <param name="particleName">Particle name.</param>
    /// <param name="position">Position.</param>
    /// 



    //指定座標に表示する
    public static void PlayParticle(string particleName, Vector3 position)
    {
        ParticlePooler pooler = particlePoolerList.Where(tempPooler => tempPooler.ParticleName == particleName).FirstOrDefault();
        if (pooler == null)
        {
            //取得できなければ新たに生成
            pooler = new ParticlePooler(particleName);
            particlePoolerList.Add(pooler);
        }
        pooler.Play(position);
    }

    //親オブジェクト指定可能
    public static void PlayParticle(string particleName, string objName, string keyName)
    {  
        ParticlePooler pooler = particlePoolerList.Where(tempPooler => tempPooler.ParticleName == particleName).FirstOrDefault();
        if (pooler == null)
        {
            //取得できなければ新たに生成
            pooler = new ParticlePooler(particleName,keyName);
            particlePoolerList.Add(pooler);
        }
        pooler.Play(objName);
    }







    //キーで指定したパーティクルの停止
    public static void StopParticle(string keyName)
    {
        var tags = GameObject.FindGameObjectsWithTag(keyName);
        foreach (var tag in tags)
        {
            tag.GetComponent<ParticleSystem>().Stop();
        }

    }

}