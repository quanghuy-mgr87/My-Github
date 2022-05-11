import HelloWorld from "./components/HelloWorld.vue";
import News from "./components/News.vue";
import Contact from "./components/Contact.vue";
import User from "./components/User.vue";

export const routes = [
  {
    path: "/home",
    component: HelloWorld,
  },
  {
    path: "/news",
    component: News,
  },
  {
    path: "/contact",
    component: Contact,
  },
  {
    path: "/user/:id",
    component: User,
  },
];
