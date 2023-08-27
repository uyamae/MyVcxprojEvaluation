#include <iostream>

class TestApp {
public:
    TestApp()
    {
        std::cout << "TestApp()" << std::endl;
    }
    ~TestApp()
    {
        std::cout << "~TestApp()" << std::endl;
    }
};

int main(int argc, char ** argv)
{
    TestApp app;
    std::cout << "main()" << std::endl;
    return 0;
}
