<template>
  <v-app>
    <v-sheet height="1000" class="overflow-hidden" style="position: relative">
      <!-- <v-container class="fill-height"> -->
      <v-container>
        <v-app-bar app color="blue" dark>
          <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
          <v-avatar color="blue" class="mr-2">
            <!-- <v-img src="./logo/logoInsta.png"> </v-img> -->
            <v-icon color="white" size="35">fas fa-globe-asia</v-icon>
          </v-avatar>
          <h3>Our Planet</h3>
        </v-app-bar>
        <v-main>
          <!-- <HelloWorld /> -->
          <router-view></router-view>
        </v-main>
      </v-container>

      <v-navigation-drawer app v-model="drawer" absolute temporary>
        <v-list-item>
          <v-list-item-avatar>
            <v-img src="https://i.pinimg.com/736x/29/ab/5a/29ab5acafc429ac807f72aece29a5695.jpg"> </v-img>
          </v-list-item-avatar>

          <v-list-item-content>
            <v-list-item-title>Name</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-divider></v-divider>

        <v-list dense>
          <v-list-item to="/mainPage" link>
            <v-list-item-icon>
              <v-icon>fas fa-home</v-icon>
            </v-list-item-icon>

            <v-list-item-content>
              <v-list-item-title>Home</v-list-item-title>
            </v-list-item-content>
          </v-list-item>

          <v-list-item link>
            <v-list-item-icon>
              <v-icon>fas fa-comment-dots</v-icon>
            </v-list-item-icon>

            <v-list-item-content>
              <v-list-item-title>About</v-list-item-title>
            </v-list-item-content>
          </v-list-item>

          <!--  -->
          <v-dialog v-model="dialog" persistent max-width="600px">
            <template v-slot:activator="{ on, attrs }">
              <v-list-item link v-bind="attrs" v-on="on">
                <v-list-item-icon>
                  <v-icon>fas fa-user-plus</v-icon>
                </v-list-item-icon>

                <v-list-item-content>
                  <v-list-item-title>Register</v-list-item-title>
                </v-list-item-content>
              </v-list-item>
            </template>
            <v-card>
              <v-card-title>
                <span class="headline">User Profile</span>
              </v-card-title>
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12">
                      <v-text-field label="Full name*" v-model="user.fullName" required></v-text-field>
                    </v-col>

                    <v-col cols="12">
                      <v-radio-group v-model="user.gen" row>
                        Giới tính:
                        <v-radio value="male" label="Nam" class="ml-2"></v-radio>
                        <v-radio value="female" label="Nữ"></v-radio>
                      </v-radio-group>
                    </v-col>

                    <v-col cols="12" sm="4">
                      <v-text-field type="number" label="Age*" v-model="user.age" required></v-text-field>
                    </v-col>

                    <v-col cols="12" sm="8">
                      <v-menu ref="menu1" v-model="menu1" :close-on-content-click="false" transition="scale-transition" offset-y max-width="290px" min-width="290px">
                        <template v-slot:activator="{ on, attrs }">
                          <v-text-field
                            v-model="user.dateFormatted"
                            label="Date of birth"
                            hint="DD/MM/YYYY format"
                            persistent-hint
                            prepend-icon="event"
                            v-bind="attrs"
                            @blur="date = parseDate(user.dateFormatted)"
                            v-on="on"
                          ></v-text-field>
                        </template>
                        <v-date-picker v-model="date" no-title @input="menu1 = false"></v-date-picker>
                      </v-menu>
                    </v-col>

                    <v-col cols="12">
                      <v-text-field label="Email*" v-model="user.email" required></v-text-field>
                    </v-col>

                    <!-- <v-col cols="12" sm="6">
                      <v-text-field label="Password*" type="password" required></v-text-field>
                    </v-col>

                    <v-col cols="12" sm="6">
                      <v-text-field label="Confirm*" type="password" required></v-text-field>
                    </v-col> -->

                    <v-col cols="12" sm="6">
                      <v-select label="Address" :items="['Ha Noi', 'Ha Nam', 'Nam Dinh', 'Ninh Binh']" v-model="user.address" required></v-select>
                    </v-col>

                    <v-col cols="12" sm="6">
                      <v-autocomplete :items="['Skiing', 'Ice hockey', 'Soccer', 'Basketball', 'Hockey', 'Reading', 'Writing', 'Coding', 'Basejump']" label="Interests" multiple></v-autocomplete>
                    </v-col>

                    <v-col cols="12">
                      <v-textarea rows="4" label="Introduce yourself" v-model="user.introduce"></v-textarea>
                    </v-col>
                  </v-row>
                </v-container>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="dialog = false">Close</v-btn>
                <v-btn color="blue darken-1" text @click="updateUserInfor">Save</v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>

          <!--  -->

          <v-list-item to="/userInfor" @click="updateUserInfor" link>
            <v-list-item-icon>
              <v-icon>fas fa-user</v-icon>
            </v-list-item-icon>
            <v-list-item-content>
              <v-list-item-title>User Profile</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </v-navigation-drawer>

      <v-navigation-drawer app right color="blue" dark width="88">
        <v-list dense>
          <v-list-item style="height: 55px">
            <v-list-item-content>
              <b> Topic </b>
            </v-list-item-content>
          </v-list-item>

          <v-divider></v-divider>

          <v-list-item v-for="(item, index) in contents" :key="index" link>
            <v-list-item-content>
              <v-list-item-title>{{ item }}</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </v-navigation-drawer>
    </v-sheet>
  </v-app>
</template>

<script>
import { eventBus } from "./main.js";
export default {
  name: "App",

  data() {
    return {
      dialog: false,
      drawer: null,
      contents: ["Animals", "Plants", "Universe"],
      date: new Date().toISOString().substr(0, 10),

      menu1: false,

      user: {
        fullName: "",
        age: null,
        email: "",
        address: "",
        dateFormatted: this.formatDate(new Date().toISOString().substr(0, 10)),
        introduce: "",
        gen: "",
      },
    };
  },

  computed: {
    computedDateFormatted() {
      return this.formatDate(this.date);
    },
  },

  watch: {
    date() {
      this.user.dateFormatted = this.formatDate(this.date);
    },
    dateOfBirth() {
      this.user.dateOfBirth = this.date;
    },
  },

  methods: {
    updateUserInfor() {
      eventBus.$emit("userInfor", this.user);
      this.dialog = false;
    },
    formatDate(date) {
      if (!date) return null;

      const [year, month, day] = date.split("-");
      return `${day}/${month}/${year}`;
    },
    parseDate(date) {
      if (!date) return null;

      const [day, month, year] = date.split("/");
      return `${year}-${month.padStart(2, "0")}-${day.padStart(2, "0")}`;
    },
  },
};
</script>
