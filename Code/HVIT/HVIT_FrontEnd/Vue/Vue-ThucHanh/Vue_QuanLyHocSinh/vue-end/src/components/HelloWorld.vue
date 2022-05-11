<template>
  <v-data-table :headers="headers" :items="desserts" sort-by="calories" class="elevation-1">
    <template v-slot:top>
      <v-btn @click="getData">Test</v-btn>
      <v-toolbar flat color="white">
        <v-toolbar-title>Danh sách học sinh</v-toolbar-title>
        <v-divider class="mx-4" inset vertical></v-divider>
        <v-spacer></v-spacer>
        <v-dialog v-model="dialog" max-width="500px">
          <template v-slot:activator="{ on, attrs }">
            <v-btn color="primary" dark class="mb-2" v-bind="attrs" v-on="on">Thêm học sinh</v-btn>
          </template>
          <v-card>
            <v-card-title>
              <span class="headline">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field v-model="editedItem.hoTen" label="Tên học sinh"></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field v-model="editedItem.lop" label="Lớp"></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-menu ref="menu1" v-model="menu1" :close-on-content-click="false" transition="scale-transition" offset-y max-width="290px" min-width="290px">
                      <template v-slot:activator="{ on, attrs }">
                        <v-text-field
                          v-model="dateFormatted"
                          label="Date"
                          hint="DD/MM/YYYY format"
                          persistent-hint
                          prepend-icon="event"
                          v-bind="attrs"
                          @blur="date = parseDate(dateFormatted)"
                          v-on="on"
                        ></v-text-field>
                      </template>
                      <v-date-picker v-model="date" no-title @input="menu1 = false"></v-date-picker>
                    </v-menu>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field v-model="editedItem.queQuan" label="Quê quán"></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" text @click="close">Cancel</v-btn>
              <v-btn color="blue darken-1" text @click="save">Save</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
    </template>
    <template v-slot:[`item.actions`]="{ item }">
      <v-icon small class="mr-2" @click="editItem(item)">
        mdi-pencil
      </v-icon>
      <v-icon small @click="deleteItem(item)">
        mdi-delete
      </v-icon>
    </template>
    <template v-slot:no-data>
      <v-btn color="primary" @click="initialize">Reset</v-btn>
    </template>
  </v-data-table>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      //date
      date: new Date().toISOString().substr(0, 10),
      dateFormatted: this.formatDate(new Date().toISOString().substr(0, 10)),
      menu1: false,

      dialog: false,
      headers: [
        {
          text: "Tên học sinh",
          align: "start",
          sortable: false,
          value: "hoTen",
        },
        { text: "Lớp", value: "lop" },
        { text: "Ngày sinh", value: "ngaySinh" },
        { text: "Quê quán", value: "queQuan" },
        { text: "Actions", value: "actions", sortable: false },
      ],
      desserts: [],
      editedIndex: -1,
      editedItem: {
        hoTen: "",
        lop: "",
        ngaySinh: null,
        queQuan: "",
      },
      defaultItem: {
        hoTen: "",
        lop: "",
        ngaySinh: null,
        queQuan: "",
      },
    };
  },
  computed: {
    //date
    computedDateFormatted() {
      return this.formatDate(this.date);
    },

    formTitle() {
      return this.editedIndex === -1 ? "Thêm học sinh" : "Sửa thông tin học sinh";
    },
  },

  watch: {
    //date
    date() {
      this.dateFormatted = this.formatDate(this.date);
    },

    dialog(val) {
      val || this.close();
    },
  },

  created() {
    this.initialize();
    this.getData();
  },

  methods: {
    //getData
    getData() {
      axios.get("https://localhost:44389/api/hocsinh").then(function(response) {
        //this.data = response.data;
        console.log(response.data[0].hoTen);
      });
    },

    //date
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

    initialize() {
      this.desserts = [
        {
          hoTen: "Nguyen Ba Quang Huy",
          lop: "Tin",
          ngaySinh: "22/05/1997",
          queQuan: "Ha Nam",
        },
      ];
    },

    editItem(item) {
      this.editedIndex = this.desserts.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
    },

    deleteItem(item) {
      const index = this.desserts.indexOf(item);
      confirm("Are you sure you want to delete this item?") && this.desserts.splice(index, 1);
    },

    close() {
      this.dialog = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },

    save() {
      if (this.editedIndex > -1) {
        Object.assign(this.desserts[this.editedIndex], this.editedItem);
      } else {
        this.desserts.push(this.editedItem);
      }
      this.close();
    },
  },
};
</script>
