"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.navItems = [
    {
        name: 'Dashboard',
        url: '/dashboard',
        icon: 'icon-speedometer',
        badge: {
            variant: 'info',
            text: 'NEW'
        }
    },
    {
        title: true,
        name: 'Equipment'
    },
    {
        name: 'New Equipment',
        url: '#',
        icon: 'icon-drop'
    },
    {
        name: 'All Equipments',
        url: '/theme/typography',
        icon: 'icon-pencil'
    },
    {
        title: true,
        name: 'Repair'
    },
    {
        name: 'New Repair',
        url: '#',
        icon: 'icon-puzzle',
    },
    {
        name: 'All Repair',
        url: '#',
        icon: 'icon-cursor',
    },
    {
        name: 'Reports',
        url: '/charts',
        icon: 'icon-pie-chart'
    },
    {
        name: 'Icons',
        url: '#',
        icon: 'icon-star',
    },
    //{
    //  name: 'Notifications',
    //  url: '/notifications',
    //  icon: 'icon-bell',
    //  children: [
    //    {
    //      name: 'Alerts',
    //      url: '/notifications/alerts',
    //      icon: 'icon-bell'
    //    },
    //    {
    //      name: 'Badges',
    //      url: '/notifications/badges',
    //      icon: 'icon-bell'
    //    },
    //    {
    //      name: 'Modals',
    //      url: '/notifications/modals',
    //      icon: 'icon-bell'
    //    }
    //  ]
    //},
    //{
    //  name: 'Widgets',
    //  url: '#',
    //  icon: 'icon-calculator',
    //  badge: {
    //    variant: 'info',
    //    text: 'NEW'
    //  }
    //},
    {
        title: true,
        name: 'Purchase'
    },
    {
        title: true,
        name: 'Consumption'
    },
    {
        divider: true
    },
    {
        title: true,
        name: 'Extras',
        attributes: { disabled: true }
    },
    {
        name: 'Pages',
        url: '#',
        icon: 'icon-star',
    },
    {
        name: 'Disabled',
        url: '/dashboard',
        icon: 'icon-ban',
        badge: {
            variant: 'secondary',
            text: 'NEW'
        },
        attributes: { disabled: true },
    }
];
//# sourceMappingURL=_nav.js.map