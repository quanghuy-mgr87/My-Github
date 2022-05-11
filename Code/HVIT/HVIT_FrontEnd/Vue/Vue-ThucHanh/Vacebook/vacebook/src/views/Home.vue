<template>
  <div class="container-fluid p-0">
    <!-- #region header -->
    <web-header></web-header>
    <!-- #endregion header -->
    <!-- #region main -->
    <div id="main">
      <div class="container-fluid">
        <div class="row">
          <!--#region Left sidebar -->
          <left-sidebar></left-sidebar>
          <!--#endregion Left sidebar  -->

          <!--#region Content -->
          <content-bar></content-bar>
          <!--#endregion Content  -->

          <!--#region Right sidebar -->
          <right-sidebar></right-sidebar>
          <!--#endregion Right sidebar -->
        </div>
      </div>
    </div>
    <!-- #endregion main -->

    <!-- #region footer -->
    <div id="footer"></div>
    <!-- #endregion footer -->
  </div>
</template>
<script>
import LeftSidebar from "../components/LeftSidebar.vue";
import ContentBar from "../components/ContentBar.vue";
import RightSidebar from "../components/RightSidebar.vue";
import WebHeader from "../components/WebHeader.vue";
export default {
  components: {
    LeftSidebar,
    ContentBar,
    RightSidebar,
    WebHeader,
  },
  data() {
    return {
      userAvatar: {
        huy:
          "https://scontent.fhan3-1.fna.fbcdn.net/v/t1.0-9/118641346_1729373410560565_7058860402179674119_o.jpg?_nc_cat=106&_nc_sid=09cbfe&_nc_ohc=AN9QQQM08H0AX9kEjTW&_nc_ht=scontent.fhan3-1.fna&oh=444c57279a86b8780f8637471df289d8&oe=5F7A0F0B",
        maria: [
          "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcR160xJNuIEy676ns4LppT0jDWZxUD_uwLsKg&usqp=CAU",
          "https://instagram.fhan3-2.fna.fbcdn.net/v/t51.2885-15/sh0.08/e35/s750x750/89690453_511475649755547_5161606507901878723_n.jpg?_nc_ht=instagram.fhan3-2.fna.fbcdn.net&_nc_cat=103&_nc_ohc=Vdhkw29RZlMAX90FWoX&oh=00699d13259960c4f4718e1c60305539&oe=5F81AC40",
        ],
        linh:
          "https://instagram.fhan3-2.fna.fbcdn.net/v/t51.2885-15/e35/p1080x1080/116227507_647881259474749_8440815342935106578_n.jpg?_nc_ht=instagram.fhan3-2.fna.fbcdn.net&_nc_cat=101&_nc_ohc=gz02I4VVvmYAX-iZvV_&oh=9a6d60b38f8c3e2bef437b1ec380ba4a&oe=5F8129F9",
      },

      storyImage: {
        huyStory:
          "https://scontent.fhan3-1.fna.fbcdn.net/v/t1.0-9/118665729_1726647494166490_8967369214768105628_n.jpg?_nc_cat=104&_nc_sid=0debeb&_nc_ohc=N8Ax3YkwgGsAX_i_PwI&_nc_oc=AQlqFbQspASPtmlKd1DtmoMwCWbBNvfeuT-P3aii1-QAyrMWoCRLF1ePGPo3e3IbzOU&_nc_ht=scontent.fhan3-1.fna&oh=cfaf4cfac627d4c74c1ecf7694298f8c&oe=5F7AB245",
        mariaStory: [
          "https://scontent.fhan3-1.fna.fbcdn.net/v/t1.0-9/118904588_417590529220242_4039607430045584142_n.jpg?_nc_cat=102&_nc_sid=8bfeb9&_nc_ohc=mvSFv0tAdYIAX-1oShM&_nc_oc=AQne7dAMn1qWQAJPRnVPwvoQdLLAJJfMx9lIhMPpwkyE1AJy1kbl6rw74DOG9aYmgDM&_nc_ht=scontent.fhan3-1.fna&oh=bafbed89f83f0b664e716a875f29802d&oe=5F7C4C7D",
          "https://scontent.fhan3-2.fna.fbcdn.net/v/t1.0-9/117039978_392300318415930_3999528415021311407_n.jpg?_nc_cat=107&_nc_sid=8bfeb9&_nc_ohc=AlE7YG1VTvAAX-4WKc1&_nc_ht=scontent.fhan3-2.fna&oh=44b85504ffd9fbab965858b6ef0c6110&oe=5F7D54E1",
        ],
        linhStory:
          "https://instagram.fhan3-1.fna.fbcdn.net/v/t51.2885-15/e35/p1080x1080/116423302_124192595713770_4341330633689069111_n.jpg?_nc_ht=instagram.fhan3-1.fna.fbcdn.net&_nc_cat=106&_nc_ohc=REesoYWhfeEAX_W6Oe2&oh=359cb2415354e3a96c3daeb37a2b4dca&oe=5F80FF87",
      },
    };
  },
};
</script>
