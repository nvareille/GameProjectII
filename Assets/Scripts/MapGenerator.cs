using UnityEngine;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;

using Access = System.Boolean;

public class MapGenerator : MonoBehaviour {

	[SerializeField]
	private GameObject Bloc1;
	[SerializeField]
	private GameObject Bloc2;
	[SerializeField]
	private GameObject Bloc3;
	[SerializeField]
	private GameObject Bloc4;
	[SerializeField]
	private GameObject Bloc5;

	public struct pair {
		public GameObject gameobject;
		public Vector2 pos;
	};

	public struct bloc {
		public GameObject name;
		public bool up;
		public bool down;
		public bool left;
		public bool right;
		public int nbtime;

		public bloc(GameObject n, bool u, bool d, bool l, bool r, int t) {
			this.name = n;
			this.up = u;
			this.down = d;
			this.left = l;
			this.right = r;
			this.nbtime = t;
		}
	};

	// UP, DOWN, LEFT, RIGHT
	bloc[] tuples;
	Access AsAccess = true;
	Access AsNotAccess = false;
	bool [][] map;
	List<pair> level;


	void Awake() {
		this.level = new List<pair>();
		this.tuples = new bloc[5];
		this.map = new bool[10][];
		this.tuples [0] = new bloc(Bloc1, AsNotAccess, AsAccess, AsNotAccess, AsNotAccess, 3);
		this.tuples [1] = new bloc(Bloc2, AsAccess, AsNotAccess, AsNotAccess, AsNotAccess, 5);
		this.tuples [2] = new bloc(Bloc3, AsNotAccess, AsNotAccess, AsAccess, AsNotAccess, 7);
		this.tuples [3] = new bloc(Bloc4, AsNotAccess, AsNotAccess, AsNotAccess, AsAccess, 3);
		this.tuples [4] = new bloc(Bloc5, AsAccess, AsAccess, AsAccess, AsAccess, 1);

		for (int i = 0; i != 10; ++i) {
			this.map[i] = new bool[10];
		}

		for (int x = 0; x != 10; ++x) {
			for (int y = 0; y != 10; ++y) {
				this.map[y][x] = false;
			}
		}
	}

	enum Direction {UP, DOWN, LEFT, RIGHT};


	private void generateBloc(Vector2 translation, int x, int y, Direction dir) {
		if (x >= 9 || y >= 9 || x <= 0 || y <= 0 || map[y][x] == true)
			return;
		List<bloc> list = new List<bloc> ();
		int size = 0;

		if (dir == Direction.UP) {
			foreach (bloc w in  this.tuples) {
				if (w.up == true && w.nbtime > 0) {
					++size;
					list.Add (w);
				}
			}
		} else if (dir == Direction.DOWN) { 
			foreach (bloc w in  this.tuples) {
				if (w.down == true && w.nbtime > 0) {
					++size;
					list.Add (w);
				}
			}
		} else if (dir == Direction.LEFT) {
			foreach (bloc w in  this.tuples) {
				if (w.left == true && w.nbtime > 0) {
					++size;
					list.Add (w);
				}
			}
		} else if (dir == Direction.RIGHT) {
			foreach (bloc w in  this.tuples) {
				if (w.right == true && w.nbtime > 0) {
					++size;
					list.Add (w);
				}
			}
		}

		if (size == 0) {
			return;
		}

		map [y] [x] = true;

		int j = Random.Range (0, size);
		bloc a = list [j];

		for (int i = 0; i != this.tuples.Length; ++i) {
			if (this.tuples[i].name == a.name) {
				this.tuples[i].nbtime -= 1;
			}
		}

		pair ed = new pair();
		print (a.name);
		GameObject zez = Instantiate (a.name);
		ed.gameobject = zez;
		ed.pos = new Vector2 (translation.x, translation.y);
		this.level.Add (ed);

		if (a.up == true) {

			Vector2 newPosition = new Vector2 (translation.x, translation.y);
			newPosition.y += 10;
			generateBloc(newPosition, x, y - 1, Direction.UP);
		}
		if (a.down == true) {

			Vector2 newPosition = new Vector2 (translation.x, translation.y);
			newPosition.y -= 10;
			generateBloc(newPosition, x, y + 1, Direction.DOWN);
		}
		if (a.right == true) {

			Vector2 newPosition = new Vector2 (translation.x, translation.y);
			newPosition.x += 21;
			generateBloc(newPosition, x + 1, y, Direction.RIGHT);
		}
		if (a.left == true) {
	
			Vector2 newPosition = new Vector2 (translation.x, translation.y);
			newPosition.x -= 21;
			generateBloc(newPosition, x - 1, y, Direction.LEFT);
		}

	}

	// Use this for initialization
	void Start () {
		if (firstCall) {

			map [5] [5] = true;
			generateBloc (new Vector2 (0, 10), 5, 4, Direction.UP);
			generateBloc (new Vector2 (0, -10), 5, 6, Direction.DOWN);
			generateBloc (new Vector2 (21, 0), 6, 5, Direction.RIGHT);
			generateBloc (new Vector2 (-21, 0), 4,5, Direction.LEFT);
			firstCall = false;
		}
	}

	bool firstCall = true;
	
	// Update is called once per frame
	void Update () {

		List<pair> removeObject = new List<pair>(); 
		foreach (pair a in this.level) {
			try {
				a.gameobject.transform.Translate (a.pos);
				removeObject.Add (a);
			} catch  {
			} finally {
			}
		}

		foreach (pair a in removeObject) {
			this.level.Remove(a);
		}
	}
}
