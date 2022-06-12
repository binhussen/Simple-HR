import { Menu } from "../models/menu";


export const menus: Array<Menu> = [
  {
    name: 'Dashboard',
    icon: 'dashboard',
    link: 'dashboard',
    open: true,
  },
  {
    name: 'Company ',
    icon: 'apartment',
    link: 'dashboard',
    open: false,
  },
  {
    name: 'Department',
    icon: 'person',
    link: 'dashboard',
    open: false,
  },
  {
    name: 'Employee',
    icon: 'badge',
    link: 'dashboard',
    open: false,
  },
  {
    name: 'LookUps',
    icon: 'dns',
    open: false,
    sub: [
      {
        name: 'Salary',
        link: 'weapon/notifies',
        open: false,
      },
      {
        name: 'Address',
        link: 'weapon/inventories',
        open: false,
      },
      {
        name: 'TaxLookUp',
        link: 'weapon/requests',
        open: false,
      }
    ],
  },
  {
    name: 'User Management',
    icon: 'manage_accounts',
    link: 'dashboard',
    open: false,
  },
];
