using UnityEngine;
using System ;
using System.Collections;

/// <summary>
/// Scene をまたぐ object を作成するために singleton を使用する
/// ってことで 作成
/// tag 検索が早いってことで、テラシュールブログさんのコードを参考に
/// </summary>
public abstract class SingletonBehaviour< T > : MonoBehaviour where T : SingletonBehaviour<T> {

	//	singleton
	protected static T	instance_ ;

	///	<summary>
	/// tag で検索が前提なので singleton を使用するオブジェクトに設定する tag を決める
	///	</summary>
	protected static readonly string	my_tag_	= "GameController" ;

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static T Instance
	{
		get{
			if (instance_ == null) {
				Type my_type		= typeof(T);
				GameObject[] objs	= GameObject.FindGameObjectsWithTag ( my_tag_ );

				foreach( var obj in objs ){
					instance_	= ( T )obj.GetComponent (my_type);
					if (null != instance_) {
						return instance_;
					}
				}
			}

			return instance_;
		}
	}

	//	instance check
	protected bool	CheckInstance()
	{
		if (instance_ == null) {
			instance_	= (T)this;
			return true;
		}
		else if( instance_ == this ){
			return true;
		}

		Destroy (this);
		return false;
	}

	//	MonoBehaviour の起動
	virtual protected void	Awake()
	{
		CheckInstance ();
	}
}
