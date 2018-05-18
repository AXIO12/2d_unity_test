using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class ParticleManager{

	/// <summary>
	/// プール用オブジェクトのリスト
	/// </summary>
	private static List<ParticlePooler> particlePoolerList = new List<ParticlePooler>();
    //private static Dictionary<string, ParticlePooler> particlePoolerList = new Dictionary<string, ParticlePooler>();

    /// <summary>
    /// 指定した名前のパーティクル再生
    /// 	初めて再生するパーティクルはプール用オブジェクトを生成
    /// </summary>
    /// <param name="particleName">Particle name.</param>
    /// <param name="position">Position.</param>
    public static void PlayParticle(string particleName, Vector3 position)
    {
        //リストから指定した名前のプール用オブジェクトを取得
        ParticlePooler pooler = particlePoolerList.Where(tempPooler => tempPooler.ParticleName == particleName).FirstOrDefault();
        if (pooler == null)
        {
            //取得できなければ新たに生成
            Debug.Log("生成");
            pooler = new ParticlePooler(particleName);
            particlePoolerList.Add(pooler);
        }
        pooler.Play(position);
    }

    public static void PlayParticle(string particleName, string name)
    {
        //リストから指定した名前のプール用オブジェクトを取得
        ParticlePooler pooler = particlePoolerList.Where(tempPooler => tempPooler.ParticleName == particleName).FirstOrDefault();
        if (pooler == null)
        {
            //取得できなければ新たに生成
            Debug.Log("生成");
            pooler = new ParticlePooler(particleName);
            particlePoolerList.Add(pooler);
        }
        pooler.Play(name);
    }

    public static void PlayParticle(string particleName, string name, string objName)
    {
        //リストから指定した名前のプール用オブジェクトを取得
        ParticlePooler pooler = particlePoolerList.Where(tempPooler => tempPooler.ParticleName == particleName).FirstOrDefault();
        if (pooler == null)
        {
            //取得できなければ新たに生成
            Debug.Log("生成");
            pooler = new ParticlePooler(particleName,objName);
            particlePoolerList.Add(pooler);
        }
        pooler.Play(name);
    }

    public static void StopParticle(string objName)
    {

        var tags = GameObject.FindGameObjectsWithTag(objName);
        foreach (var tag in tags)
        {
            tag.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

    }

}