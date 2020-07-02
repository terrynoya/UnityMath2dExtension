using Com.JoeYao.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToLineProjection : MonoBehaviour {

	[SerializeField]
	private Transform _pointTrans;
	[SerializeField]
	private Transform _lineStartTrans;
	[SerializeField]
	private Transform _lineEndTrans;

	[SerializeField]
	private Transform _pointProjTrans;

	private Vector2 _lineStart;
	private Vector2 _lineEnd;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		_lineStart = GetV2(_lineStartTrans);
		_lineEnd = GetV2(_lineEndTrans);

		//Vector2 lineVec = _lineEnd - _lineStart;

		Vector2 p = GetV2(_pointTrans);
		//Vector2 pVec = p - _lineStart;

		//float project = Project(pVec, lineVec);
		//Vector2 lineDir = lineVec.normalized;
		//Vector2 proVec = project * lineDir;

		Vector2 proVec = Math2d.GetPointProjectVectorOnLine(p, _lineStart, _lineEnd);

		_pointProjTrans.position = _lineStartTrans.position + new Vector3(proVec.x, 0, proVec.y);
	}

	private Vector2 GetV2(Transform t)
	{
		Vector3 p = t.position;
		return new Vector2(p.x, p.z);
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawLine(_lineStartTrans.position, _lineEndTrans.position);
		Gizmos.DrawLine(_pointTrans.position, _pointProjTrans.position);
	}
}
