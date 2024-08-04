import { UsergroupDeleteOutlined, DesktopOutlined, } from '@ant-design/icons';
import { Menu } from 'antd';
import { useState } from 'react';
import { Outlet, Link } from 'react-router-dom';


const Header = () => {
    const [current, setCurrent] = useState('h');
    const onClick = (e) => {
        setCurrent(e.key);
    };
    return (
        <>
            <Menu onClick={onClick} selectedKeys={[current]} mode="horizontal">
                <Menu.Item key="h" icon={<DesktopOutlined/>}>
                    <Link to="/cafe">Cafe</Link>
                </Menu.Item>
                <Menu.Item key="r" icon={<UsergroupDeleteOutlined />}>
                    <Link to="/employee?cafe">Employee</Link>
                </Menu.Item>
            </Menu>
            <Outlet />
        </>

    )
};
export default Header;