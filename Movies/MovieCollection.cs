// CAB301 - assignment 2
// An implementation of MovieCollection ADT
// 2023


using System;

//A class that models a node of a binary search tree
//An instance of this class is a node in the binary search tree 
public class BTreeNode
{
	private IMovie movie; // movie
	private BTreeNode? lchild; // reference to its left child 
	private BTreeNode? rchild; // reference to its right child

	public BTreeNode(IMovie movie)
	{
		this.movie = movie;
		lchild = null;
		rchild = null;
	}

	public IMovie Movie
	{
		get { return movie; }
		set { movie = value; }
	}

	public BTreeNode? LChild
	{
		get { return lchild; }
		set { lchild = value; }
	}

	public BTreeNode? RChild
	{
		get { return rchild; }
		set { rchild = value; }
	}
}

// invariant: no duplicate movie in this movie collection
public class MovieCollection : IMovieCollection
{
	private BTreeNode? root; // the root of the binary search tree in which movies are stored 
	private int count; // the number of movies currently stored in this movie collection 



	public int Number { get { return count; } }

	// constructor - create an empty movie collection
	public MovieCollection()
	{
		root = null;
		count = 0;	
	}

	public bool IsEmpty()
	{
        return root == null;
    }


	public bool Insert(IMovie movie)
	{
        if (root == null) {
            root = new BTreeNode(movie);
            count += 1;
            return true;
        }
        else
        {
            return Insert(movie, root);
        }
    }

    // pre: ptr != null
    // post: item is inserted to the binary search tree rooted at ptr
    private bool Insert(IMovie movie, BTreeNode parent)
    {
        if (movie.CompareTo(parent.Movie) < 0)
        {
            if (parent.LChild == null) {
                parent.LChild = new BTreeNode(movie);
                count += 1;
                return true;
            }
            else
            {
                return Insert(movie, parent.LChild);
            }
                
        }
        else if (movie.CompareTo(parent.Movie) > 0)
        {
            if (parent.RChild == null) {
                parent.RChild = new BTreeNode(movie);
                count += 1;
                return true;
            }
            else
            {
                return Insert(movie, parent.RChild);
            }
        }
        else
        {
            return false;
        }
    }

    // there are three cases to consider:
    // 1. the node to be deleted is a leaf
    // 2. the node to be deleted has only one child 
    // 3. the node to be deleted has both left and right children
    public bool Delete(IMovie movie)
    {
        // search for item and its parent
        BTreeNode ptr = root; // search reference
        BTreeNode parent = null; // parent of ptr
        while ((ptr != null) && (movie.CompareTo(ptr.Movie) != 0))
        {
            parent = ptr;
            if (movie.CompareTo(ptr.Movie) < 0) // move to the left child of ptr
                ptr = ptr.LChild;
            else
                ptr = ptr.RChild;
        }

        if (ptr != null) // if the search was successful
        {
            // case 3: item has two children
            if ((ptr.LChild != null) && (ptr.RChild != null))
            {
                // find the right-most node in left subtree of ptr
                if (ptr.LChild.RChild == null) // a special case: the right subtree of ptr.LChild is empty
                {
                    ptr.Movie = ptr.LChild.Movie;
                    ptr.LChild = ptr.LChild.LChild;
                }
                else
                {
                    BTreeNode p = ptr.LChild;
                    BTreeNode pp = ptr; // parent of p
                    while (p.RChild != null)
                    {
                        pp = p;
                        p = p.RChild;
                    }
                    // copy the item at p to ptr
                    ptr.Movie = p.Movie;
                    pp.RChild = p.LChild;
                }
            }
            else // cases 1 & 2: item has no or only one child
            {
                BTreeNode c;
                if (ptr.LChild != null)
                    c = ptr.LChild;
                else
                    c = ptr.RChild;

                // remove node ptr
                if (ptr == root) //need to change root
                    root = c;
                else
                {
                    if (ptr == parent.LChild)
                        parent.LChild = c;
                    else
                        parent.RChild = c;
                }
            }
            count -= 1;
            return true;
        }
        else
        {
            return false;
        }
    }

    public IMovie? Search(string movietitle)
	{
        return Search(movietitle, root);
    }

    private IMovie? Search(string title, BTreeNode parent)
    {
        if (parent != null)
        {
            if (title.CompareTo(parent.Movie.Title) == 0)
                return parent.Movie;
            else if (title.CompareTo(parent.Movie.Title) < 0)
                return Search(title, parent.LChild);
            else
                return Search(title, parent.RChild);
        }
        else
            return null;
    }

    public int NoDVDs()
	{
        int noDVDs = 0;
        int count = 0;
        InOrderTraverse(root);
        void InOrderTraverse(BTreeNode root)
        {
            count++;
            if (root != null)
            {
                InOrderTraverse(root.LChild);
                noDVDs += root.Movie.TotalCopies;
                InOrderTraverse(root.RChild);
            }
        }
        return noDVDs;
        return count;
    }

    public IMovie[] ToArray()
	{
        int i = 0;
        IMovie[] movieArray = new IMovie[count];

        InOrderTraverse(root);
        void InOrderTraverse(BTreeNode root)
        {
            if (root != null)
            {
                InOrderTraverse(root.LChild);
                movieArray[i++] = root.Movie;
                InOrderTraverse(root.RChild);
            }
        }
        return movieArray;
    }

	public void Clear()
	{
        root = null;

    }
}





