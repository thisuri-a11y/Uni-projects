class Node{
	int data;
	Node right;
	Node left;
	
	Node(int data){
		this.data = data;
	}
}

class BinaryTree{
	Node root;
	
	void preOrder(Node node){
		if(node == null) return;
		System.out.print(node.data+" ");
		preOrder(node.left);
		preOrder(node.right);
	}
	
	void postOrder(Node node){
		if(node == null) return;
		postOrder(node.left);
		postOrder(node.right);
		System.out.print(node.data + " ");
	}
	
	void inOrder(Node node){
		if(node == null) return;
		inOrder(node.left);
		System.out.print(node.data + " ");
		inOrder(node.left);
		
	}
	
	public static void main(String[] args){
		BinaryTree bt = new BinaryTree();
		
		bt.root = new Node(10);
		bt.root.left = new Node(8);
		bt.root.left.left = new Node(6);
		bt.root.right = new Node(12);
		
		bt.preOrder(bt.root);
		System.out.println();
		bt.postOrder(bt.root);
		System.out.println();
		bt.inOrder(bt.root);
		
		
		
	}
	
}