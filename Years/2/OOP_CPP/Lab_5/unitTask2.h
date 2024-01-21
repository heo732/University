//---------------------------------------------------------------------------
#ifndef unitTask2H
#define unitTask2H
#include <Classes.hpp>
#include <Grids.hpp>
//---------------------------------------------------------------------------
class Node
{
        public:

        double data;
        Node* right;
        Node* left;

        Node()
        {
                right = NULL;
                left = NULL;
                data = 0;
        }

        Node(Node& a)
        {
                right = NULL;
                left = NULL;
                data = a.data;
        }

        Node(double a)
        {
                right = NULL;
                left = NULL;
                data = a;
        }

        ~Node()
        {
                /*if(left != NULL)
                        delete left;
                if(right != NULL)
                        delete right;
                left = NULL;
                right = NULL; */
        }

        Node& operator = (Node& a)
        {
                data = a.data;
                return *this;
        }

        bool operator < (Node& a)
        {
                return data < a.data ? true : false;
        }

        bool operator < (double a)
        {
                return data < a ? true : false;
        }

        bool operator == (Node& a)
        {
                return data == a.data ? true : false;
        }

        bool operator == (double a)
        {
                return data == a ? true : false;
        }

        int getData()
        {
                return data;
        }

        void setData(double a)
        {
                data = a;
        }

        Node* getLeft()
        {
                return left;
        }

        Node* getRight()
        {
                return right;
        }
};
//---------------------------------------------------------------------------
class Tree
{
        private:

        Node* root;

        int heightNode(Node* n)
        {
                if(n!=NULL)
                        return heightNode(n->getLeft()) > heightNode(n->getRight()) ? heightNode(n->getLeft())+1 : heightNode(n->getRight())+1;
                return 0;
        }

        int cntNodes(Node* n)
        {
                if(n!=NULL)
                        return cntNodes(n->getLeft()) + cntNodes(n->getRight()) + 1;
                return 0;
        }

        void printSG(Node* n, int rang, TStringGrid*& stg)
        {
                if(n!=NULL)
                {
                        printSG(n->getLeft(), rang+1, stg);
                        stg->Cells[stg->ColCount-1][rang] = FloatToStr(n->getData());
                        stg->ColCount++;
                        printSG(n->getRight(), rang+1, stg);
                }
        }

        void addNode(Node*& n, double d)
        {
                if(n == NULL)
                {
                        n = new Node(d);
                }
                else if(*n == d)
                        ;//
                else if(d < n->getData())
                        addNode(n->left, d);
                else
                        addNode(n->right, d);
        }

        Node* findNode(Node* n, double a)
        {
                if(n == NULL)
                        return NULL;
                if(findNode(n->left, a) != NULL)
                        return findNode(n->left, a);
                if(findNode(n->right, a) != NULL)
                        return findNode(n->right, a);
                if(n->data == a)
                        return n;
                return NULL;                                
        }

        public:

        Tree()
        {
                root = NULL;
        }

        Tree(int a)
        {
                root = new Node(a);
        }

        ~Tree()
        {
                if(root != NULL)
                {
                        delete root;
                        root = NULL;
                }        
        }

        void add(int a)
        {
                addNode(root, a);
        }

        int height()
        {
                return heightNode(root);
        }

        int countNodes()
        {
                return cntNodes(root);
        }
        
        void printStringGrid(TStringGrid*& stg)
        {
                stg->ColCount = countNodes();
                stg->RowCount = height();
                stg->FixedCols = 0;
                stg->FixedRows = 0;
                for(int i = 0; i < stg->ColCount; i++)
                        for(int j = 0; j < stg->RowCount; j++)
                                stg->Cells[i][j] = "";
                stg->ColCount = 1;
                printSG(root, 0, stg);
                stg->ColCount--;
        }

        void erase()
        {
                if(root != NULL)
                {
                        delete root->left;
                        delete root->right;
                        root->left = NULL;
                        root->right = NULL;
                        delete root;
                        root = NULL;
                }
        }

        Node* find(double a)
        {
                return findNode(root, a);
        }
};
//---------------------------------------------------------------------------
#endif
